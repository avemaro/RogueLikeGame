using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaker {
    public static Floor Create(string[] data) {
        var floor = new Floor(data);
        floor.Rooms.Add(new Room());
        floor.Rooms.Add(new Room());


        return floor;
    }
}
