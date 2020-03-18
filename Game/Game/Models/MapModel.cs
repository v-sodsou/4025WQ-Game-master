using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Represents the map.
    /// </summary>
    public class MapModel
    {
        // The X axies Size
        public int MapXAxiesCount = 6;

        // The Y axies Size
        public int MapYAxiesCount = 6;

        // The Map Locations
        public MapModelLocation[,] MapGridLocation;

        public PlayerInfoModel EmptySquare = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Unknown, ImageURI = "mapcell.png" };

        public MapModel()
        {
            // Create the Map
            MapGridLocation = new MapModelLocation[MapXAxiesCount, MapYAxiesCount];

        }

    }
}
