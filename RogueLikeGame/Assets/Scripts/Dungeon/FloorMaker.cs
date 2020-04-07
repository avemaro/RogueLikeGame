using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaker {
    public static Floor Create(string[] data) {
        return new Floor(data);
    }
}
