﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature: Stuff {
    public Direction direction;
    public State state;

    public bool Attack() {
        var to = Position.Next(direction);
        return floor.IsAttacked(to);
    }

    public void IsAttacked() {
        state = State.Dead;

        if (state == State.Dead)
            floor.Remove(this);
    }

    public virtual bool Move(Direction direction) {
        if (state == State.Dead) return false;

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
        if (floor.GetEnemy(to) != null) return false;
        if (floor.Player.Position == to) return false;

        if (!direction.IsDiagonal()) return true;

        var forwards = Position.Next(direction.Forwards());
        if (floor.GetTerrain(forwards).Contains(TerrainType.wall)) return false;

        return true;
    }

    public void Fly(Direction direction) {
        var nextCell = floor.GetTerrainCell(Position);
        while (true) {
            nextCell = nextCell.Next(direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;
            Position = nextCell;
        }
    }
}
