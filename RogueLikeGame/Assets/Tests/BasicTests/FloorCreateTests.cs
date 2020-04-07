using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FloorCreateTests
    {
        [Test]
        public void TwoRoomHasConnected() {
            string[] floorData = {
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆",
                "◆◆試　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　　　　　　　　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　　◆◆",
                "◆◆　　　　　　　◆◆◆◆◆◆　　　　　　階◆◆",
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆"
            };

            var floor = FloorMaker.Create(floorData);
            floor.PrintFloor();

            Assert.AreEqual(2, floor.Rooms.Count);
            var player = floor.Player;
            Assert.AreEqual(floor.Rooms[0], player.Room);
            player.Move(3, 3, 3, 3);

            for (var i = 0; i < 8; i++) {
                player.Move(Direction.right);
                Assert.AreNotEqual(floor.Rooms[1], player.Room);
            }
            player.Move(Direction.right);
            Assert.AreEqual(floor.Rooms[1], player.Room);
            floor.PrintFloor();
        }
    }
}
