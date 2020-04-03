
public enum TerrainType {
    wall = '◆', land = '　', water = '◇'
}

public static class TerrainTypeExtend {
    public static TerrainType GetTrrainType(char data) {
        switch (data) {
            case '◆': return TerrainType.wall;
            case '◇': return TerrainType.water;
        }
        return TerrainType.land;
    }
}