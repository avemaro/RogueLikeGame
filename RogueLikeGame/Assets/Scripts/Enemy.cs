using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    static readonly List<char> IDs = new List<char>() { 'マ', 'ギ', '武' };
    public new static Enemy Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Enemy(floor, cell, data);
    }

    private Enemy(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    public void Work() {
        foreach (var direction in DirectionExtend.AllCases()) {
            var cell = Position.Next(direction);
            if (floor.Player.Position != cell) continue;
            this.direction = direction;
            break;
        }
        Attack();
    }

    public void Fly(Direction direction) {
        var nextCell = floor.GetTerrainCell(Position);
        while (true) {
            nextCell = nextCell.Next(direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;
            Position = nextCell;
        }
    }
}