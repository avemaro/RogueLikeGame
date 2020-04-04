using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stuff {
    protected Floor floor;
    public Cell Position { get; set; }
    public char ID { get; protected set; }

    public static Stuff Create(Floor floor, Cell cell, char data) {
        if (data == '草' || data == '杖')
            return Item.Create(floor, cell, data);
        if (data == 'マ')
            return Enemy.Create(floor, cell, data);
        return null;
    }
}
