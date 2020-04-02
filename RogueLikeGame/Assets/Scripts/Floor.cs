﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Floor {


    (int x, int y) floorSize;
    Dictionary<(int x, int y), TerrainType> terrains = new Dictionary<(int x, int y), TerrainType>();
    public Player player = new Player();

    public Floor(string[] floorData) {
        floorSize.x = floorData[0].Length;
        floorSize.y = floorData.Length;

        for (var x = 0; x < floorSize.x; x++) {
            for (var y = 0; y < floorSize.y; y++) {
                var data = floorData[y].ToCharArray()[x];
                TerrainType terrain = TerrainTypeExtend.GetTrrainType(data);
                terrains.Add((x, y), terrain);

                if (data == '試') player.Position = (x, y);
            }
        }
    }

    public TerrainType GetTerrain(int x, int y) {
        return terrains[(x, y)];
    }

    public void PrintFloor() {
        for (var x = 0; x < floorSize.x; x++) {
            var str = "";
            for (var y = 0; y < floorSize.y; y++) {
                char data = '　';
                switch (terrains[(x, y)]) {
                    case TerrainType.wall: data = '◆'; break;
                    case TerrainType.water: data = '◇'; break;
                    case TerrainType.stair: data = '階'; break;
                }
                if (player.Position == (x, y)) data = '試';

                str += data;
            }
            Debug.Log(str);
        }
    }
}