using System;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    (int x, int y) floorSize;
    readonly List<TerrainCell> terrains = new List<TerrainCell>();
    public Cell StairPosition { get; private set; }
    public Player Player { get; private set; }
    List<Enemy> enemies = new List<Enemy>();
    List<Item> items = new List<Item>();

    public Floor(string[] floorData) {
        Player = new Player(this);

        floorSize.x = floorData[0].Length;
        foreach (var data in floorData)
            if (floorSize.x < data.Length) floorSize.x = data.Length;

        floorSize.y = floorData.Length;

        for (var x = 0; x < floorSize.x; x++) {
            for (var y = 0; y < floorSize.y; y++) {
                var cell = new Cell(x, y);
                var data = floorData[y].ToCharArray()[x];
                TerrainType terrain = TerrainTypeExtend.GetTrrainType(data);
                terrains.Add(new TerrainCell(this, cell, terrain));

                if (data == '草') items.Add(new Item(this, cell));
                if (data == 'マ') enemies.Add(new Enemy(this, cell));
                if (data == '試') Player.Position = cell;
                if (data == '階') StairPosition = cell;
            }
        }
    }

    #region terrain
    public TerrainCell GetTerrainCell(Cell to) {
        foreach (var terrain in terrains)
            if (terrain.Equals(to.Tuple)) return terrain;
        return null;
    }

    internal void IsAttaced(Cell to) {
        var nextCell = GetTerrainCell(to);
        if (nextCell.type != TerrainType.breakableWall) return;
        nextCell.type = TerrainType.land;

        foreach (var direction in DirectionExtend.AllCases()) {
            nextCell = (TerrainCell)GetTerrainCell(to).Next(direction);
            IsAttaced(nextCell);
        }
    }

    public TerrainType GetTerrain(int x, int y) {
        return GetTerrain(new Cell(x, y));
    }

    public TerrainType GetTerrain(Cell cell) {
        return GetTerrainCell(cell).type;
    }

    public List<TerrainType> GetTerrain(List<Cell> cells) {
        var terrains = new List<TerrainType>();
        foreach (var cell in cells)
            terrains.Add(GetTerrain(cell));
        return terrains;

    }
    #endregion

    public Item GetItem(int x, int y) {
        foreach (var item in items)
            if (item.Position == (x, y)) return item;
        return null;
    }

    public Enemy GetEnemy(int x, int y) {
        foreach (var enemy in enemies)
            if (enemy.Position == (x, y)) return enemy;
        return null;
    }

    public List<string> PrintFloor() {
        var floorData = new List<string>();
        for (var y = 0; y < floorSize.y; y++) {
            var str = "";
            for (var x = 0; x < floorSize.x; x++) {
                char data = (char)GetTerrainCell(new Cell(x, y)).type;

                if (GetItem(x, y) != null) data = '草';
                if (GetEnemy(x, y) != null) data = 'マ';
                if (StairPosition == (x, y)) data = '階';
                if (Player.Position == (x, y)) data = '試';
                str += data;
            }
            floorData.Add(str);
            Debug.Log(str);
        }
        return floorData;
    }
}