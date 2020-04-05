using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap: Stuff {
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
            case '罠': floor.Player.IsAttacked(); return;
            case '跳':
                floor.Player.Jump();
                return;
            case '爆':
                foreach (var cell in Position.Around) {
                    floor.IsAttacked(floor.Player, cell);
                }
                return;
        }
    }
}