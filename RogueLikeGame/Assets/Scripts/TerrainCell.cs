using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCell : Cell {
    readonly Floor floor;
    public TerrainType type;

    public TerrainCell(Floor floor, int x, int y, TerrainType type): base(x, y){
        this.floor = floor;
        this.type = type;
    }

    public TerrainCell(Floor floor, Cell cell, TerrainType type) : base(cell.x, cell.y) {
        this.floor = floor;
        this.type = type;
    }

    public override Cell Next(Direction direction) {
        var next = base.Next(direction);
        return floor.GetTerrainCell(next);
    }
}
