using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    static readonly List<char> IDs = new List<char>() { 'マ', 'ギ', '武', 'ク' };
    public new static Enemy Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        if (data == 'ク') return new Bowboy(floor, cell, data);
        return new Enemy(floor, cell, data);
    }

    readonly Brain brain;

    protected Enemy(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        brain = new Brain(floor, this);
    }

    public void Work() {
        brain.Work();
    }
}

public class Bowboy : Enemy {
    public Bowboy(Floor floor, Cell cell, char data): base(floor, cell, data) {
    }

    public override bool Attack() {
        var nextCell = Position;
        while (true) {
            nextCell = nextCell.Next(direction);
            if (floor.IsAttacked(nextCell)) return true;
            if (floor.GetTerrain(nextCell) == TerrainType.wall) return false;
        }
    }
}