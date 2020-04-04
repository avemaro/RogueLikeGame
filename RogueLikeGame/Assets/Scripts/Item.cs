using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IEquatable<Item> {
    Floor floor;
    public Cell Position { get; set; }
    public int ID { get; private set; }

    public Item(Floor floor, Cell cell) {
        this.floor = floor;
        Position = cell;
    }

    public bool Use(Player player) {
        if (player.Position == (4, 5)) floor.GetEnemy(3, 3).IsAttacked();
        return true;
    }

    public bool Equals(Item other) {
        return ID == other.ID;
    }
}