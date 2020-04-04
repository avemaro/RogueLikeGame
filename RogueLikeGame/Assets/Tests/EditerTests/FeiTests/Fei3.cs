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
                "◆　　マ　　◆◆◆◆　◆",
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
            var item = floor.GetStuff(3, 5);
            floor.PrintFloor();

            player.Move(Direction.up);
            floor.PrintFloor();

            Assert.AreEqual(item, player.Items[0]);
        }
    }
}
