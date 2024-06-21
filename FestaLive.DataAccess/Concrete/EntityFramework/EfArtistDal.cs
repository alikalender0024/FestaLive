using FestaLive.Core.DataAccess.Concrete.EntityFramework;
using FestaLive.DataAccess.Abstract;
using FestaLive.DataAccess.Concrete.Context;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.DataAccess.Concrete.EntityFramework
{
    public class EfArtistDal : EfEntityRepositoryBase<Artist, FestaLiveContext>, IArtistDal
    {
    }
}
