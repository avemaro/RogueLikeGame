using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Floor {
    Dictionary<(int x, int y), TerrainType> terrains = new Dictionary<(int x, int y), TerrainType>();
    Player player;

    public Floor(Player player, string[] floorData) {
        this.player = player;

        var sizeX = floorData[0].Length;
        var sizeY = floorData.Length;

        for (var x = 0; x < sizeX; x++) {
            for (var y = 0; y < sizeY; y++) {
                TerrainType terrain = TerrainType.land;
                switch (floorData[y].ToCharArray()[x]) {
                    case '◆': terrain = TerrainType.wall; break;
                    case '◇': terrain = TerrainType.water; break;
                    case '階': terrain = TerrainType.stair; break;
                    case '試': player.Position = (x, y); break;
                }
                terrains.Add((x, y), terrain);
            }
        }
    }

    public TerrainType GetTerrain(int x, int y) {
        return terrains[(x, y)];
    }
}