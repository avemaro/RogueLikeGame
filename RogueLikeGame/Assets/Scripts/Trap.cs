using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap: Stuff, IAttacker {
    static readonly List<char> IDs = new List<char>() { '罠', '跳', '爆' };
    public new static Trap Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Trap(floor, cell, data);
    }

    private Trap(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        isVisible = false;
    }

    public void Work() {
        if (floor.Player.Position != Position) return;
        isVisible = true;

        switch (ID) {
            case '罠': floor.Player.IsAttacked(this); return;
            case '跳':
                floor.Player.Jump();
                return;
            case '爆':
                foreach (var cell in Position.Around) {
                    var enemy = floor.GetEnemy(cell);
                    if (enemy != null) enemy.IsAttacked(this);
                }
                return;
        }
    }

    public bool Attack() {
        throw new System.NotImplementedException();
    }

    public bool IsAttacked(IAttacker attacker) {
        throw new System.NotImplementedException();
    }
}