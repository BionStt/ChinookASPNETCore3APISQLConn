﻿using System.Collections.Generic;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels
{
    public class PlaylistApiModel : IConvertModel<PlaylistApiModel, Playlist>
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }
        public IList<PlaylistTrackApiModel> PlaylistTracks { get; set; }

        public Playlist Convert() =>
            new Playlist
            {
                PlaylistId = PlaylistId,
                Name = Name
            };
    }
}