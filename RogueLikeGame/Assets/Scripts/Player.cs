
using System.Collections.Generic;

public class Player {
    public Floor floor;
    public Cell Position { get; set; }

    public Player(Floor floor) {
        this.floor = floor;
    }

    public void Attack() {

    }

    public bool Move(Direction direction) {
        if (!IsRegal(direction)) return false;
        Position = Position.Next(direction);
        return true;
    }

    public bool Move(List<Direction> directions) {
        var hasMoved = true;
        foreach (var direction in directions)
            if (!Move(direction)) hasMoved = false;
        return hasMoved;
    }

    bool IsRegal(Direction direction) {
        var to = Position.Next(direction);
        if (floor.GetTerrain(to) != TerrainType.land) return false;

        if (!direction.IsDiagonal()) return true;

        var forwards = Position.Next(direction.Forwards());
        if (floor.GetTerrain(forwards).Contains(TerrainType.wall)) return false;

        return true;
    }
}
