using System.Collections.Generic;
using UnityEngine;

public class Floor {
    (int x, int y) floorSize;
    Dictionary<(int x, int y), TerrainType> terrains = new Dictionary<(int x, int y), TerrainType>();
    public Cell StairPosition { get; private set; }
    public Player Player { get; private set; }

    public Floor(string[] floorData) {
        Player = new Player(this);

        floorSize.x = floorData[0].Length;
        foreach (var data in floorData)
            if (floorSize.x < data.Length) floorSize.x = data.Length;

        floorSize.y = floorData.Length;

        for (var x = 0; x < floorSize.x; x++) {
            for (var y = 0; y < floorSize.y; y++) {
                var data = floorData[y].ToCharArray()[x];
                TerrainType terrain = TerrainTypeExtend.GetTrrainType(data);
                terrains.Add((x, y), terrain);

                if (data == '試') Player.Position = new Cell(x, y);
                if (data == '階') StairPosition = new Cell(x, y);
            }
        }
    }

    public TerrainType GetTerrain(Cell cell) {
        return GetTerrain(cell.x, cell.y);
    }

    public List<TerrainType> GetTerrain(List<Cell> cells) {
        var terrains = new List<TerrainType>();
        foreach (var cell in cells)
            terrains.Add(GetTerrain(cell));
        return terrains;
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
                if (StairPosition == (x, y)) data = '階';
                str += data;
            }
            Debug.Log(str);
        }
    }
}