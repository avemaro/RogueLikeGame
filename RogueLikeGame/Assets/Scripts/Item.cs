using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IEquatable<Item> {
    readonly Floor floor;
    public Cell Position { get; set; }
    public int ID { get; private set; }

    public Item(Floor floor, Cell cell) {
        this.floor = floor;
        Position = cell;
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