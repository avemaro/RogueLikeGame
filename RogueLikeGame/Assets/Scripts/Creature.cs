using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature: Stuff {
    protected Floor floor;
    public Cell Position { get; set; }
    public Direction direction;
    public State State { get; protected set; }

    public void Attack() {
        var to = Position.Next(direction);
        floor.IsAttacked(to);
    }

    public void IsAttacked() {
        State = State.Dead;
    }

    public virtual bool Move(Direction direction) {
        if (State == State.Dead) return false;

        this.direction = direction;

        if (!IsRegalMove()) return false;
        Position = Position.Next(direction);

        return true;
    }

    public bool Move(List<Direction> directions) {
        var hasMoved = true;
        foreach (var direction in directions)
            if (!Move(direction)) hasMoved = false;
        return hasMoved;
    }

    public bool Move(params int[] indexes) {
        var directions = DirectionExtend.GetDirections(indexes);
        return Move(directions);
    }

    bool IsRegalMove() {
        var to = Position.Next(direction);
        if (floor.GetTerrain(to) != TerrainType.land) return false;

        if (!direction.IsDiagonal()) return true;

        var forwards = Position.Next(direction.Forwards());
        if (floor.GetTerrain(forwards).Contains(TerrainType.wall)) return false;

        return true;
    }
}
