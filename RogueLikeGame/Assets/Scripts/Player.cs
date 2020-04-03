using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public (int x, int y) Position { get; set; }

    public bool Move(Direction direction) {
        return true;
    }
}
