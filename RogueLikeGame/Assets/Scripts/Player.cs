using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public Cell Position { get; set; }

    public bool Move(Direction direction) {
        if (direction == Direction.downRight) return false;
        Position = Position.Next(direction);
        return true;
    }
}
