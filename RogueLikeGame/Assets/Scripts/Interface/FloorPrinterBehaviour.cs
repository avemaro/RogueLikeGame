using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorPrinterBehaviour : MonoBehaviour, IFloorDisplay
{
    Floor floor;
    public Text floorPrefab;
    Text text;
    readonly int width = 11;
    readonly int height = 11;

    void Start() {
        text = Instantiate(floorPrefab, transform);

        floor = new Floor(text.text) {
            floorDisplay = this
        };
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.W)) {
            floor.Player.Move(Direction.up);
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            floor.Player.Move(Direction.upRight);
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            floor.Player.Move(Direction.right);
        }
        if (Input.GetKeyUp(KeyCode.C)) {
            floor.Player.Move(Direction.downRight);
        }
        if (Input.GetKeyUp(KeyCode.X)) {
            floor.Player.Move(Direction.down);
        }
        if (Input.GetKeyUp(KeyCode.Z)) {
            floor.Player.Move(Direction.downLeft);
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            floor.Player.Move(Direction.left);
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            floor.Player.Move(Direction.upLeft);
        }

        Show();
    }

    public void Show() {
        text.text = "";

        var center = floor.Player.Position;
        for (var y = -height / 2; y < height / 2 + 1; y++) {
            var line = "";
            for (var x = -width / 2; x < width / 2 + 1; x++) {
                var position = center + (x, y);
                char data = GetChar(position.x, position.y);
                line += data;
            }
            text.text += line;
            text.text += "\n";
        }
    }

    char GetChar(int x, int y) {
        char data = '◆';
        if (x > 0 && y > 0 &&
            x < floor.floorSize.x && y < floor.floorSize.y) {
            data = (char)floor.GetTerrain(x, y);
            if (floor.StairPosition == (x, y)) data = '階';
            var stuff = floor.GetStuff(x, y);
            if (stuff != null) {
                data = stuff.ID;
                if (!stuff.isVisible) data = '　';
                if (stuff is Enemy) {
                    if (((Enemy)stuff).state == State.Dead) data = '　';
                }
            }
            if (floor.Player.Position == (x, y)) data = '試';
        }
        return data;
    }
}
