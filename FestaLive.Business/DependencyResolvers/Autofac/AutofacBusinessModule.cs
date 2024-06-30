using Autofac;
using FestaLive.Business.Abstract;
using FestaLive.Business.Concrete;
using FestaLive.Core.Utilities.Security.Jwt;
using FestaLive.DataAccess.Abstract;
using FestaLive.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<ArtistManager>().As<IArtistService>().SingleInstance();
            builder.RegisterType<EfArtistDal>().As<IArtistDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<CalendarManager>().As<ICalendarService>().SingleInstance();
            builder.RegisterType<EfCalendarDal>().As<ICalendarDal>().SingleInstance();

            builder.RegisterType<ContactFormManager>().As<IContactFormService>().SingleInstance();
            builder.RegisterType<EfContactFormDal>().As<IContactFormDal>().SingleInstance();

            builder.RegisterType<EventManager>().As<IEventService>().SingleInstance();
            builder.RegisterType<EfEventDal>().As<IEventDal>().SingleInstance();

            builder.RegisterType<FeatureManager>().As<IFeatureService>().SingleInstance();
            builder.RegisterType<EfFeatureDal>().As<IFeatureDal>().SingleInstance();

            builder.RegisterType<FooterManager>().As<IFooterService>().SingleInstance();
            builder.RegisterType<EfFooterDal>().As<IFooterDal>().SingleInstance();

            builder.RegisterType<PlanManager>().As<IPlanService>().SingleInstance();
            builder.RegisterType<EfPlanDal>().As<IPlanDal>().SingleInstance();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>().SingleInstance();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>().SingleInstance();

            builder.RegisterType<TicketManager>().As<ITicketService>().SingleInstance();
            builder.RegisterType<EfTicketDal>().As<ITicketDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

        }
    }
}
