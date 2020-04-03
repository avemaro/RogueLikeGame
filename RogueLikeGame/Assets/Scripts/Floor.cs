using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Floor {


    (int x, int y) floorSize;
    Dictionary<(int x, int y), TerrainType> terrains = new Dictionary<(int x, int y), TerrainType>();
    public Player Player { get; private set; } = new Player();

    public Floor(string[] floorData) {
        floorSize.x = floorData[0].Length;
        floorSize.y = floorData.Length;

        for (var x = 0; x < floorSize.x; x++) {
            for (var y = 0; y < floorSize.y; y++) {
                var data = floorData[y].ToCharArray()[x];
                TerrainType terrain = TerrainTypeExtend.GetTrrainType(data);
                terrains.Add((x, y), terrain);

                if (data == '試') Player.Position = (x, y);
            }
        }
    }

    public TerrainType GetTerrain(int x, int y) {
        return terrains[(x, y)];
    }

    public void PrintFloor() {
        for (var y = 0; y < floorSize.y; y++) {
            var str = "";
            for (var x = 0; x < floorSize.x; x++) {
                char data = (char)terrains[(x, y)];
                if (Player.Position == (x, y)) data = '試';
                str += data;
            }
            Debug.Log(str);
        }
    }
}