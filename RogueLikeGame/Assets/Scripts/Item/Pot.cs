using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item {
    static readonly List<char> IDs = new List<char>()
    { 'ト' };
    public static new Pot Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Pot(floor, cell, data);
    }

    protected Pot(Floor floor, Cell cell, char data) : base(floor, cell, data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    public override bool Use(Player player) {
        return true;
    }
}