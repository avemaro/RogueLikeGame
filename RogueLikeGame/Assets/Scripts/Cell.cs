using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : IEquatable<Cell>, IEquatable<(int x, int y)> {
    int x;
    int y;

    public Cell(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public Cell Next(Direction direction) {
        return new Cell(x + direction.GetValue().x, y + direction.GetValue().y);
    }

    public bool Equals(Cell other) {
        return other.x == x && other.y == y;
    }

    public bool Equals((int x, int y) other) {
        return other.x == x && other.y == y;
    }

    public static bool operator ==(Cell lhs, (int x, int y) rhs) {
        return lhs.x == rhs.x && lhs.y == rhs.y;
    }

    public static bool operator !=(Cell lhs, (int x, int y) rhs) {
        return lhs.x != rhs.x || lhs.y != rhs.y;
    }

    public override bool Equals(object obj) {
        return base.Equals(obj);
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }
}