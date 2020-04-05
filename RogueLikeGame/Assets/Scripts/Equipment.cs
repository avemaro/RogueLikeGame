﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item {
    static readonly List<char> IDs = new List<char>() { 'つ', '透' };
    public new static Equipment Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Equipment(floor, cell, data);
    }

    protected Equipment(Floor floor, Cell cell, char data): base(floor, cell, data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }
}