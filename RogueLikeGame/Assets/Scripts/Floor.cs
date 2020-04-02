using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    public Floor(string floorName) {

    }

    public TerrainType GetTerrain(int x, int y) {
        if (x == 0 && y == 0) return TerrainType.wall;
        if (x == 1 && y == 1) return TerrainType.land;
        if (x == 4 && y == 1) return TerrainType.water;
        return TerrainType.wall;
    }
}
