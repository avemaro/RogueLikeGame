using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Item {
    static readonly List<char> IDs = new List<char>()
    { '杖', '縛', '吹' };
    public static new Wand Create(Floor floor, Cell cell, char data) {
        if (!IDs.Contains(data)) return null;
        return new Wand(floor, cell, data);
    }

    protected Wand(Floor floor, Cell cell, char data) : base(floor, cell, data) {
        this.floor = floor;
        Position = cell;
        ID = data;
        durability = 3;
    }

    public override bool Use(Player player) {
        durability--;
        Debug.Log("Wand");
        var nextCell = floor.GetTerrainCell(player.Position);

        while (true) {
            nextCell = nextCell.Next(player.direction);
            if (nextCell.type != TerrainType.land &&
                nextCell.type != TerrainType.water) break;

            var enemy = floor.GetEnemy(nextCell.x, nextCell.y);
            if (enemy == null) continue;

            if (ID == '杖') {
                var temp = player.Position;
                player.Position = enemy.Position;
                enemy.Position = temp;
            }
            if (ID == '吹')
                enemy.Fly(player.direction);
            if (ID == '縛')
                enemy.state = State.Sleep;
            break;
        }
        return true;
    }
}