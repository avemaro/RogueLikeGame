using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff, IEquatable<Item> {
    int durability = 1;

    private Item(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        if (data == '杖') durability = 3;
    }

    public new static Item Create(Floor floor, Cell cell, char data) {
        if (data != '草' && data != '杖') return null;
        return new Item(floor, cell, data);
    }

    public bool Use(Player player) {
        durability--;
        if (durability <= 0) player.Items.Remove(this);

        var nextCell = floor.GetTerrainCell(player.Position);

        while (true) {
            nextCell = nextCell.Next(player.direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;

            var enemy = floor.GetEnemy(nextCell.x, nextCell.y);
            if (enemy == null) continue;

            if (ID == '草') enemy.IsAttacked();
            if (ID == '杖') {
                var temp = player.Position;
                player.Position = enemy.Position;
                enemy.Position = temp;
            }
            break;
        }
        return true;
    }

    public bool Throw(Player player) {
        return Use(player);
    }

    public bool Equals(Item other) {
        return ID == other.ID;
    }
}