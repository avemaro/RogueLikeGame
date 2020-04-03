using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    up, upRight, right, downRight, down, downLeft, left, upLeft
}

public static class DirectionExtend {
    public static (int x, int y) GetValue(this Direction direction) {
        switch (direction) {
            case Direction.up: return (0, -1);
            case Direction.upRight: return (1, -1);
            case Direction.right: return (1, 0);
            case Direction.downRight: return (1, 1);
            case Direction.down: return (0, 1);
            case Direction.downLeft: return (-1, 1);
            case Direction.left: return (-1, 0);
            case Direction.upLeft: return (-1, -1);
            default: return (0, 0);
        }
    }
}