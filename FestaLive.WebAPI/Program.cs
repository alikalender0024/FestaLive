using Autofac.Extensions.DependencyInjection;
using Autofac;
using FestaLive.Business.DependencyResolvers.Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FestaLive.Core.Utilities.Security.Jwt;
using FestaLive.Core.Utilities.Security.Encryption;
using FestaLive.Core.DependencyResolvers;
using FestaLive.Core.Utilities.IoC;

var host = CreateHostBuilder(args).Build();

host.Run();

static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Autofac ile bağımlılık enjeksiyonunu yapılandır
        builder.RegisterModule(new AutofacBusinessModule());
    }).
    ConfigureWebHostDefaults(webBuilder =>
    {
        // ASP.NET Core web host konfigürasyonu
        webBuilder.Configure(app =>
        {

            //Bu kısım, ASP.NET Core web host konfigürasyonunu içerir.
            //HTTPS yönlendirmesi, yetkilendirme, rota kullanımı ve Swagger entegrasyonu gibi middleware'leri ekler.
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();

            // UseAuthorization should come after UseRouting
            app.UseAuthentication(); // bir yere girmek için anahtardır. (ortama giriş anahtarı)
            app.UseAuthorization(); // anahtarla girdiğin yerde ne yapılabilir (yetki)


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });


        });
    }).ConfigureServices(services =>
    {
        // ASP.NET Core servisleri konfigürasyonu: ASP.NET Core servis konfigürasyonunu içerir.
        // Kontrolleri ekler, endpoint API keşfi için gerekli olan servisleri ve Swagger belgelemesi için gerekli olan servisleri ekler.
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("https://localhost:3000"));

        });

        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
        services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    });