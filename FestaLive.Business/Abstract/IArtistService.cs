﻿using FestaLive.Core.Utilities.Results;
using FestaLive.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Abstract
{
    public interface IArtistService
    {
        IResult Add(Artist artist);
        IResult Delete(int artistId);
        IResult Update(Artist artist);
        IDataResult<Artist> GetById(int artistId);
        IDataResult<List<Artist>> GetAll();
        IDataResult<List<Artist>> FilterArtists(string? name,DateTime? birthdate,string? musicGenre,string? youtubeChannel);
    }
}
