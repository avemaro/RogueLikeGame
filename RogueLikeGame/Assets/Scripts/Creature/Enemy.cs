using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    static readonly List<char> IDs = new List<char>() { 'マ', 'ギ', '武' };
    public new static Enemy Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Enemy(floor, cell, data);
    }

    Brain brain;

    private Enemy(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        brain = new Brain(floor, this);
    }

    public void Work() {
        brain.Work();
    }
}