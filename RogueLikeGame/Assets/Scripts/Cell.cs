using System;
using System.Collections.Generic;

public class Cell : IEquatable<Cell>, IEquatable<(int x, int y)> {
    public int x;
    public int y;

    public (int x, int y) Tuple {
        get { return (x, y); }
    }


    public Cell(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public virtual Cell Next(Direction direction) {
        return new Cell(x + direction.GetValue().x, y + direction.GetValue().y);
    }

    public List<Cell> Next(Direction[] directions) {
        var cells = new List<Cell>();
        foreach (var direction in directions)
            cells.Add(Next(direction));
        return cells;
    }

    public bool Equals(Cell other) {
        return other.x == x && other.y == y;
    }

    public bool Equals((int x, int y) other) {
        return other.x == x && other.y == y;
    }

    public static bool operator ==(Cell lhs, Cell rhs) {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Cell lhs, Cell rhs) {
        return !lhs.Equals(rhs);
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

    public override string ToString() {
        return "(" + x + ", " + y + ")";
    }
}