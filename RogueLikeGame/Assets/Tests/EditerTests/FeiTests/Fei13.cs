using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Fei13
    {
        string[] data;
        Floor floor;
        Player player;

        [SetUp]
        public void SetUp() {
            data = new string[] {
                "　　　　　　　　　　　◆◆◆◆◆◆◆",
                "◆◆◆◆◆◆◆◆　　　◆　武　　　◆",
                "◆　武　　　　◆　　　◆　　　武　◆",
                "◆　　　　武　◆◆◆◆◆　　　　　◆",
                "◆試真　武　　　　　　　　真　階武◆",
                "◆　　　　武　◆◆◆◆◆　　　　　◆",
                "◆　武　　　　◆　　　◆　　　武　◆",
                "◆◆◆◆◆◆◆◆　　　◆　武　　　◆",
                "　　　　　　　　　　　◆◆◆◆◆◆◆"
            };
            floor = new Floor(data);
            player = floor.Player;
        }

        [Test]
        public void Test_floorHasPrinted() {
            Assert.AreEqual(data, floor.PrintFloor());
        }
    }
}
