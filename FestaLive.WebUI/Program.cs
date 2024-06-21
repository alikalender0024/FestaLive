using Autofac.Extensions.DependencyInjection;
using Autofac;
using FestaLive.Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());

       });

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
