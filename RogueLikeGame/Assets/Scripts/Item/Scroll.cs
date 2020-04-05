using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : Item {
    static readonly List<char> IDs = new List<char>()
    { '巻', '眠', '真' };
    public static new Scroll Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Scroll(floor, cell, data);
    }

    protected Scroll(Floor floor, Cell cell, char data): base(floor, cell, data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    public override bool Use(Player player) {
        player.Items.Remove(this);

        if (ID == '眠') {
            foreach (var enemy in floor.Enemies)
                enemy.state = State.Sleep;
        }

        if (ID == '真') {
            for (var i = 0; i < floor.Enemies.Count; i++)
                floor.Enemies[i].IsAttacked(this);
        }

        return true;
    }
}