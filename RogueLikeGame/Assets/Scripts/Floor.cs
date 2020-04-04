using System;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    (int x, int y) floorSize;
    readonly List<TerrainCell> terrains = new List<TerrainCell>();
    public Cell StairPosition { get; private set; }
    public Player Player { get; private set; }

    readonly List<Enemy> enemies = new List<Enemy>();
    readonly List<Item> items = new List<Item>();
    public List<Trap> Traps { get; private set; } = new List<Trap>();

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

                if (data == '試') Player.Position = cell;
                if (data == '階') StairPosition = cell;

                var stuff = Stuff.Create(this, cell, data);
                if (stuff is Item) items.Add((Item)stuff);
                if (stuff is Enemy) enemies.Add((Enemy)stuff);
                if (stuff is Trap) Traps.Add((Trap)stuff);
            }
        }
    }

    public void Work() {
        for (var i = 0; i < enemies.Count; i++)
            enemies[i].Work();
    }

    #region terrain
    public TerrainCell GetTerrainCell(Cell to) {
        foreach (var terrain in terrains)
            if (terrain.Equals(to.Tuple)) return terrain;
        return null;
    }

    internal void IsAttacked(Cell to) {
        var nextCell = GetTerrainCell(to);
        if (nextCell.type == TerrainType.breakableWall) {
            nextCell.type = TerrainType.land;

            foreach (var direction in DirectionExtend.AllCases()) {
                nextCell = GetTerrainCell(to).Next(direction);
                if (nextCell.type != TerrainType.breakableWall) continue;
                IsAttacked(nextCell);
            }

            return;
        }

        if (Player.Position == to) Player.IsAttacked();
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

    public Stuff GetStuff(int x, int y) {
        var item = GetItem(x, y);
        if (item != null) return item;
        var enemy = GetEnemy(x, y);
        if (enemy != null) return enemy;
        var trap = GetTrap(x, y);
        if (trap != null) return trap;
        return null;
    }

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

    public Trap GetTrap(int x, int y) {
        foreach (var trap in Traps)
            if (trap.Position == (x, y)) return trap;
        return null;
    }


    public void Remove(Item item) {
        items.Remove(item);
    }

    public void Remove(Enemy enemy) {
        enemies.Remove(enemy);
    }


    public List<string> PrintFloor() {
        var floorData = new List<string>();
        for (var y = 0; y < floorSize.y; y++) {
            var str = "";
            for (var x = 0; x < floorSize.x; x++) {
                char data = (char)GetTerrainCell(new Cell(x, y)).type;

                var stuff = GetStuff(x, y);
                if (stuff != null) {
                    data = stuff.ID;
                    if (!stuff.isVisible) data = '　';
                }
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