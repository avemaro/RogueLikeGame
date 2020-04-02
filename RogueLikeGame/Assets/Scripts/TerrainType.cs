using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TerrainType {
    wall = '◆', land = '　', water = '◇', stair = '階'
}

public static class TerrainTypeExtend {
    public static TerrainType GetTrrainType(char data) {
        switch (data) {
            case '◆': return TerrainType.wall;
            case '◇': return TerrainType.water;
            case '階': return TerrainType.stair;
        }
        return TerrainType.land;
    }
}