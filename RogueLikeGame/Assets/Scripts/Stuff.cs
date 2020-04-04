using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stuff {
    protected Floor floor;
    public Cell Position { get; set; }
    public char ID { get; protected set; }

    public static Stuff Create(Floor floor, Cell cell, char data) {
        var item = Item.Create(floor, cell, data);
        if (item != null) return item;
        var enemy = Enemy.Create(floor, cell, data);
        if (enemy != null) return enemy;
        return null;
    }
}
