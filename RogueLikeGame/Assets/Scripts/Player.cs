
using System.Collections.Generic;

public class Player {
    public Floor floor;
    public Cell Position { get; set; }
    public Direction direction;
    public State State { get; private set; }

    public List<Item> Items { get; private set; } = new List<Item>();

    public Player(Floor floor) {
        this.floor = floor;
    }

    public void Attack() {
        var to = Position.Next(direction);
        floor.IsAttacked(to);
    }

    public bool Move(Direction direction) {
        this.direction = direction;

        if (!IsRegalMove()) return false;
        Position = Position.Next(direction);

        PickUp();
        floor.Work();

        return true;
    }

    public bool Move(List<Direction> directions) {
        var hasMoved = true;
        foreach (var direction in directions)
            if (!Move(direction)) hasMoved = false;
        return hasMoved;
    }

    bool IsRegalMove() {
        var to = Position.Next(direction);
        if (floor.GetTerrain(to) != TerrainType.land) return false;

        if (!direction.IsDiagonal()) return true;

        var forwards = Position.Next(direction.Forwards());
        if (floor.GetTerrain(forwards).Contains(TerrainType.wall)) return false;

        return true;
    }

    bool PickUp() {
        var item = floor.GetItem(Position.x, Position.y);
        floor.Remove(item);
        if (item != null) Items.Add(item);
        return item != null;
    }

    public void Use(int index) {
        var item = Items[index];
        if (item.Use(this))
            Items.RemoveAt(index);
    }

    public void IsAttacked() {
        State = State.Dead;
    }
}
