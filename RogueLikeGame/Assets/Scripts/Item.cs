using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff, IEquatable<Item> {
    readonly Floor floor;
    public Cell Position { get; set; }

    private Item(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
    }

    public new static Item Create(Floor floor, Cell cell, char data) {
        if (data != '草' && data != '杖') return null;
        return new Item(floor, cell, data);
    }

    public bool Use(Player player) {
        var nextCell = floor.GetTerrainCell(player.Position);

        while (true) {
            nextCell = nextCell.Next(player.direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;

            var enemy = floor.GetEnemy(nextCell.x, nextCell.y);
            if (enemy == null) continue;
            enemy.IsAttacked();
            break;
        }
        return true;
    }

    public bool Equals(Item other) {
        return ID == other.ID;
    }
}