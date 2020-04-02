using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    Dictionary<(int x, int y), TerrainType> trrains = new Dictionary<(int x, int y), TerrainType>();

    public Floor(string floorName) {
        trrains.Add((0, 0), TerrainType.wall);
        trrains.Add((1, 1), TerrainType.land);
        trrains.Add((4, 1), TerrainType.water);
    }

    public TerrainType GetTerrain(int x, int y) {
        return trrains[(x, y)];
    }
}
