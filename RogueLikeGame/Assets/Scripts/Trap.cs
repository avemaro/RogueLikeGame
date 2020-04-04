using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap: Stuff {
    static readonly List<char> IDs = new List<char>() { '罠' };
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
}