using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff, IEquatable<Item>, IAttacker {
    static readonly List<char> IDs = new List<char>()
    { '草', '眼', 'Ｇ', '薬'};
    public new static Item Create(Floor floor, Cell cell, char data) {
        var equipment = Equipment.Create(floor, cell, data);
        if (equipment != null) return equipment;
        var scroll = Scroll.Create(floor, cell, data);
        if (scroll != null) return scroll;
        var wand = Wand.Create(floor, cell, data);
        if (wand != null) return wand;
        var pot = Pot.Create(floor, cell, data);
        if (pot != null) return pot;

        if (!IDs.Contains(data)) return null;
        return new Item(floor, cell, data);
    }

    protected int durability = 1;

    protected Item(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    public virtual bool Use(Player player) {
        durability--;
        if (durability <= 0) player.Items.Remove(this);

        if (ID == '眼') {
            foreach (var trap in floor.Traps)
                trap.isVisible = true;
            return true;
        }

        var nextCell = floor.GetTerrainCell(player.Position);

        while (true) {
            nextCell = nextCell.Next(player.direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;

            var enemy = floor.GetEnemy(nextCell.x, nextCell.y);
            if (enemy == null) continue;
            if (ID == '草')
                enemy.IsAttacked(this);
            break;
        }
        return true;
    }

    public bool Throw(Player player) {
        return Use(player);
    }

    public bool Equals(Item other) {
        return base.Equals(other);
    }

    public virtual bool Attack() {
        throw new NotImplementedException();
    }

    public bool IsAttacked(IAttacker attacker) {
        throw new NotImplementedException();
    }
}