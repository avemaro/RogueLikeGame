﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Stuff, IEquatable<Item> {
    static readonly List<char> IDs = new List<char>() { '草', '杖', '巻', '吹',
        '眼', 'Ｇ', '眠', '縛', '真', '薬'};
    public new static Item Create(Floor floor, Cell cell, char data) {
        var equipment = Equipment.Create(floor, cell, data);
        if (equipment != null) return equipment;
        if (!IDs.Contains(data)) return null;
        return new Item(floor, cell, data);
    }

    int durability = 1;

    protected Item(Floor floor, Cell cell, char data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        if (data == '杖') durability = 3;
    }

    public bool Use(Player player) {
        durability--;
        if (durability <= 0) player.Items.Remove(this);

        if (ID == '眠') {
            foreach (var enemy in floor.Enemies)
                enemy.state = State.Sleep;
        }

        if (ID == '真') {
            for (var i = 0; i < floor.Enemies.Count; i++)
                floor.Enemies[i].IsAttacked();
        }

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
            if (Work(player, enemy)) break;
        }
        return true;
    }

    bool Work(Player player, Enemy enemy) {
        if (ID == '草')
            enemy.IsAttacked();
        if (ID == '杖') {
            var temp = player.Position;
            player.Position = enemy.Position;
            enemy.Position = temp;
        }
        if (ID == '吹')
            enemy.Fly(player.direction);
        if (ID == '縛')
            enemy.state = State.Sleep;

        return true;
    }

    public bool Throw(Player player) {
        return Use(player);
    }

    public bool Equals(Item other) {
        return base.Equals(other);
        //return ID == other.ID;
    }
}