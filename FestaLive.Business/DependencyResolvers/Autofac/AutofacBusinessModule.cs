using Autofac;
using FestaLive.Business.Abstract;
using FestaLive.Business.Concrete;
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
            builder.RegisterType<ArtistManager>().As<IArtistService>().SingleInstance();
            builder.RegisterType<EfArtistDal>().As<IArtistDal>().SingleInstance();
        }
    }
}
