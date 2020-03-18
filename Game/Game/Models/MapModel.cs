using System;
using System.Collections.Generic;
using System.Linq;
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

            ClearMapGrid();

        }

        /// <summary>
        /// Create an Empty Map
        /// </summary>
        /// <returns></returns>
        public bool ClearMapGrid()
        {
            //Populate Map with Empty Values
            for (var x = 0; x < MapXAxiesCount; x++)
            {
                for (var y = 0; y < MapYAxiesCount; y++)
                {
                    // Populate the entire map with blank
                    MapGridLocation[x, y] = new MapModelLocation { Row = y, Column = x, Player = EmptySquare };
                }
            }
            return true;
        }

        /// <summary>
        /// Initialize the Data Structure
        /// Add Characters and Monsters to the Map
        /// </summary>
        /// <param name="PlayerList"></param>
        /// <returns></returns>
        public bool PopulateMapModel(List<PlayerInfoModel> PlayerList)
        {
            ClearMapGrid();

            int x = 0;
            int y = 0;
            foreach (var data in PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxiesCount)
                {
                    x = 0;
                    y++;
                }
            }

            x = 0;
            y = MapYAxiesCount - 1;
            foreach (var data in PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxiesCount)
                {
                    x = 0;
                    y--;
                }
            }

            return true;
        }

    }
}
