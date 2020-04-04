using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Fei3
    {
        string[] data;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            data = new string[] {
                "◆◆◆◆◆◆◆　　　　　",
                "◆階　　　　◆◆◆◆◆◆",
                "◆　　　　　　　　　　◆",
                "◆　　　マ　◆◆◆◆　◆",
                "◆◆◆◆◇◆◆◆◆◆　◆",
                "◆　　草　　◆◆◆◆　◆",
                "◆　　試　　　　　　　◆",
                "◆　　　　　◆◆◆◆◆◆",
                "◆◆◆◆◆◆◆　　　　　"
            };
        }

        [Test]
        public void PlayerPickUpItem() {
            var floor = new Floor(data);
            var player = floor.Player;
            var item = floor.GetItem(3, 5);
            Assert.AreEqual(data, floor.PrintFloor());
            Assert.NotNull(item);

            player.Move(Direction.up);
            floor.PrintFloor();

            Assert.AreEqual(item, player.Items[0]);
            Assert.IsNull(floor.GetItem(3, 5));
        }

        [Test]
        public void PlayerUseItem() {
            var floor = new Floor(data);
            var player = floor.Player;
            var enemy = floor.GetEnemy(4, 3);
            Assert.NotNull(enemy);

            player.Move(Direction.up);
            player.Use(0);
            Assert.AreEqual(0, player.Items.Count);
            Assert.AreEqual(State.Alive, enemy.State);

            floor = new Floor(data);
            player = floor.Player;
            enemy = floor.GetEnemy(4, 3);

            player.Move(Direction.up);
            player.Move(Direction.right);
            player.Move(Direction.up);
            player.Use(0);
            Assert.AreEqual(0, player.Items.Count);
            Assert.AreEqual(State.Dead, enemy.State);
        }

        [Test]
        public void PlayerHasAttacked() {
            var floor = new Floor(data);
            var player = floor.Player;

            int[] moves = { 2, 2, 2, 2, 2,
                            2, 2, 0, 0, 0,
                            0, 6, 6, 6, 6,
                            6 };
            player.Move(DirectionExtend.GetDirections(moves));
            Debug.Log(player.Position);
            floor.PrintFloor();
            Assert.AreEqual(State.Dead, player.State);
        }
    }
}
