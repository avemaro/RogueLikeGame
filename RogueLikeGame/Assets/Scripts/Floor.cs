﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Floor {
    Dictionary<(int x, int y), TerrainType> terrains = new Dictionary<(int x, int y), TerrainType>();

    public Floor(string[] floorData) {
        var sizeX = floorData[0].Length;
        var sizeY = floorData.Length;

        for (var x = 0; x < sizeX; x++) {
            for (var y = 0; y < sizeY; y++) {
                TerrainType terrain = TerrainType.wall;
                switch (floorData[y].ToCharArray()[x]) {
                    case '◆': terrain = TerrainType.wall; break;
                    case '　': terrain = TerrainType.land; break;
                    case '◇': terrain = TerrainType.water; break;
                }
                terrains.Add((x, y), terrain);
            }
        }
    }

    public TerrainType GetTerrain(int x, int y) {
        return terrains[(x, y)];
    }
}