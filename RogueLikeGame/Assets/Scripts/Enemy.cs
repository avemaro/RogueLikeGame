using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
    Floor floor;
    public Cell Position { get; private set; }
    public State State { get; private set; }

    public Enemy(Floor floor, Cell cell) {
        this.floor = floor;
        Position = cell;
    }

    public void Work() {
        foreach (var direction in DirectionExtend.AllCases()) {
            var cell = Position.Next(direction);
            if (floor.Player.Position == cell) floor.Player.IsAttacked();
        }
    }

    public void IsAttacked() {
        State = State.Dead;
    }
}