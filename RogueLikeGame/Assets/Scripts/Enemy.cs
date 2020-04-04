using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
    public Cell Position { get; private set; }
    public State State { get; private set; }

    public Enemy(Floor floor, Cell cell) {
        Position = cell;
    }

    public void IsAttacked() {
        State = State.Dead;
    }
}