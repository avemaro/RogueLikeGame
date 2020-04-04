using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    private Enemy(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    static readonly List<char> IDs = new List<char>() { 'マ', 'ギ' };
    public new static Enemy Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Enemy(floor, cell, data);
    }

    public void Work() {
        if (State == State.Dead)
            floor.Remove(this);

        foreach (var direction in DirectionExtend.AllCases()) {
            var cell = Position.Next(direction);
            if (floor.Player.Position != cell) continue;
            this.direction = direction;
            break;
        }
        Attack();
    }
}