using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: Creature {
    public Enemy(Floor floor, Cell cell) {
        this.floor = floor;
        Position = cell;
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
}