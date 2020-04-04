using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IEquatable<Item> {
    public Cell Position { get; set; }
    public int ID { get; private set; }

    public Item(Floor floor, Cell cell) {
        Position = cell;
    }

    public bool Equals(Item other) {
        return ID == other.ID;
    }
}