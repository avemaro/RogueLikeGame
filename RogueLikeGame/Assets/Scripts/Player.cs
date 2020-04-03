using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public Floor floor;
    public Cell Position { get; set; }

    public Player(Floor floor) {
        this.floor = floor;
    }

    public bool Move(Direction direction) {
        if (!IsRegal(direction)) return false;
        Position = Position.Next(direction);
        return true;
    }

    bool IsRegal(Direction direction) {
        var to = Position.Next(direction);
        if (floor.GetTerrain(to) != TerrainType.land) return false;

        if (!direction.IsDiagonal()) return true;

        foreach (var forward in direction.Forwards()) {
            var cell = Position.Next(forward);
            if (floor.GetTerrain(cell) == TerrainType.wall) return false;
        }

        return true;
    }
}
