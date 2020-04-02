using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    public Floor(string floorName) {

    }

    public TerrainType GetTerrain(int x, int y) {
        return TerrainType.wall;
    }
}
