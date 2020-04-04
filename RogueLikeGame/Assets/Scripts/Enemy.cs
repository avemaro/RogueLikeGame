using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
    public Cell Position { get; set; }

    public Enemy(Floor floor, Cell cell) {
        Position = cell;
    }
}