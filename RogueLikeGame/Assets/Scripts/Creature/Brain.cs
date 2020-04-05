using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain {
    Floor floor;
    Enemy enemy;
    Cell destination;

    public Brain(Floor floor, Enemy enemy) {
        this.floor = floor;
        this.enemy = enemy;
    }

    public void Work() {
        if (enemy.state != State.Alive) return;

        destination = floor.Player.Position;

        foreach (var direction in DirectionExtend.AllCases()) {
            var cell = enemy.Position.Next(direction);
            if (floor.Player.Position != cell) continue;
            enemy.direction = direction;
            break;
        }

        if (enemy.Attack()) return;

        if (enemy.ID == 'マ' || enemy.ID == 'ギ') return;

        FindWay();
    }

    void FindWay() {
        var difference = destination - enemy.Position;
        var direction = difference.Direction;
        if (enemy.Move(direction)) return;

        if (!direction.IsDiagonal()) {
            if (enemy.Move(enemy.direction.TurnLeft())) return;
            if (enemy.Move(enemy.direction.TurnRight())) return;
        }

        if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y)) {
            if (difference.x > 0 && enemy.Move(Direction.right)) return;
            if (enemy.Move(Direction.left)) return;
            if (difference.y > 0 && enemy.Move(Direction.down)) return;
            if (enemy.Move(Direction.up)) return;
        } else {
            if (difference.y > 0 && enemy.Move(Direction.down)) return;
            if (enemy.Move(Direction.up)) return;
            if (difference.x > 0 && enemy.Move(Direction.right)) return;
            if (enemy.Move(Direction.left)) return;
        }

    }

}