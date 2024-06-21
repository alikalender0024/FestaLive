using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface ISocialMediaService
    {
        IResult Add(SocialMedia  socialMedia);
        IResult Delete(int socialMediaId);
        IResult Update(SocialMedia socialMedia);
        IDataResult<SocialMedia> GetById(int socialMediaId);
        IDataResult<List<SocialMedia>> GetAll();
    }
}
