using System;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    public (int x, int y) floorSize;
    readonly List<TerrainCell> terrains = new List<TerrainCell>();
    public Cell StairPosition { get; private set; }
    public Player Player { get; private set; }

    public List<Room> Rooms { get; private set; } = new List<Room>();

    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
    public List<Item> Items { get; private set; } = new List<Item>();
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
                if (stuff is Item) Items.Add((Item)stuff);
                if (stuff is Enemy) Enemies.Add((Enemy)stuff);
                if (stuff is Trap) Traps.Add((Trap)stuff);
            }
        }
    }

    public void Work() {
        Enemies.RemoveAll(enemy => enemy.state == State.Dead);

        foreach (var enemy in Enemies)
            enemy.Work();
        foreach (var trap in Traps)
            trap.Work();

        Enemies.RemoveAll(enemy => enemy.state == State.Dead);
    }

    #region terrain
    public TerrainCell GetTerrainCell(Cell to) {
        foreach (var terrain in terrains)
            if (terrain.Equals(to.Tuple)) return terrain;
        return null;
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

    #region getter
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
        foreach (var item in Items)
            if (item.Position == (x, y)) return item;
        return null;
    }

    public Enemy GetEnemy(Cell cell) {
        return GetEnemy(cell.x, cell.y);
    }

    public Enemy GetEnemy(int x, int y) {
        foreach (var enemy in Enemies)
            if (enemy.Position == (x, y)) return enemy;
        return null;
    }

    public Enemy GetEnemy(Cell from, Direction direction, List<TerrainType> blockTerrans) {
        var nextCell = GetTerrainCell(from);

        while (true) {
            nextCell = nextCell.Next(direction);
            if (blockTerrans.Contains(nextCell.type)) break;
            var enemy = GetEnemy(nextCell);
            if (enemy == null) continue;
            return enemy;
        }
        return null;
    }

    public Trap GetTrap(int x, int y) {
        foreach (var trap in Traps)
            if (trap.Position == (x, y)) return trap;
        return null;
    }
    #endregion

    public void Remove(Item item) {
        Items.Remove(item);
    }

    public void Remove(Creature creature) {
        if (creature is Enemy) Enemies.Remove((Enemy)creature);
    }


    public List<string> PrintFloor() {
        var floorData = new List<string>();
        for (var y = 0; y < floorSize.y; y++) {
            var str = "";
            for (var x = 0; x < floorSize.x; x++) {
                char data = (char)GetTerrainCell(new Cell(x, y)).type;

                if (StairPosition == (x, y)) data = '階';
                var stuff = GetStuff(x, y);
                if (stuff != null) {
                    data = stuff.ID;
                    if (!stuff.isVisible) data = '　';
                    if (stuff is Enemy) {
                        if (((Enemy)stuff).state == State.Dead) data = '　';
                    }
                }
                if (Player.Position == (x, y)) data = '試';
                str += data;
            }
            floorData.Add(str);
            Debug.Log(str);
        }
        return floorData;
    }
}