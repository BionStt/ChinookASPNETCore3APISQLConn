﻿using System.Collections.Generic;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels
{
    public class ArtistApiModel : IConvertModel<ArtistApiModel, Artist>
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public IList<AlbumApiModel> Albums { get; set; }

        public Artist Convert() =>
            new Artist
            {
                ArtistId = ArtistId,
                Name = Name
            };
    }
}