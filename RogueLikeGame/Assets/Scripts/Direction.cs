using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    up, upRight, right, downRight, down, downLeft, left, upLeft
}

public static class DirectionExtend {
    public static bool IsDiagonal(this Direction direction) {
        switch (direction) {
            case Direction.upRight:
            case Direction.downRight:
            case Direction.downLeft:
            case Direction.upLeft: return true;
            default: return false;
        }
    }

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

    public static Direction[] Forwards(this Direction direction) {
        switch (direction) {
            case Direction.up:
                return new Direction[] { Direction.upLeft, Direction.up, Direction.upRight };
            case Direction.upRight:
                return new Direction[] { Direction.up, Direction.upRight, Direction.right };
            case Direction.right:
                return new Direction[] { Direction.upRight, Direction.right, Direction.downRight };
            case Direction.downRight:
                return new Direction[] { Direction.right, Direction.downRight, Direction.down };
            case Direction.down:
                return new Direction[] { Direction.downRight, Direction.down, Direction.downLeft };
            case Direction.downLeft:
                return new Direction[] { Direction.down, Direction.downLeft, Direction.left };
            case Direction.left:
                return new Direction[] { Direction.downLeft, Direction.left, Direction.upLeft };
            case Direction.upLeft:
                return new Direction[] { Direction.left, Direction.upLeft, Direction.up };
            default: return new Direction[0];
        }
    }
}

