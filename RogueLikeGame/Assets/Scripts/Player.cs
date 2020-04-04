
using System.Collections.Generic;

public class Player: Creature {
    public List<Item> Items { get; private set; } = new List<Item>();

    public Player(Floor floor) {
        this.floor = floor;
    }

    public override bool Move(Direction direction) {
        if (!base.Move(direction)) return false;
        PickUp();
        floor.Work();
        return true;
    }

    bool PickUp() {
        var item = floor.GetItem(Position.x, Position.y);
        floor.Remove(item);
        if (item != null) Items.Add(item);
        return item != null;
    }

    public void Use(int index) {
        var item = Items[index];
        if (item.Use(this))
            Items.RemoveAt(index);
    }
}
