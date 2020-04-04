using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Fei7
    {
        string[] data;
        Floor floor;
        Player player;

        [SetUp]
        public void SetUp() {
            data = new string[] {
                "◆◆◆◆◆◆◆◆◆",
                "◆Ｇ　　　　　Ｇ◆",
                "◆　武ＧマＧギ　◆",
                "◆Ｇ武　マ　ギＧ◆",
                "◆　武　マ　ギ　◆",
                "◆　Ｇ　　　Ｇ　◆",
                "◆　◇◇◇◇◇階◆",
                "◆Ｇ　試巻　　　◆",
                "◆◆◆◆◆◆◆◆◆"
            };
            floor = new Floor(data);
            player = floor.Player;
        }

        [Test]
        public void Test_floorHasPrinted() {
            Assert.AreEqual(data, floor.PrintFloor());
        }

        [Test]
        public void Test_Fei7_Fail() {
            player.Move(2, 2, 2, 1);
            Assert.AreNotEqual(floor.StairPosition, player.Position);
        }

        [Test]
        public void Test_Fei7_Pass() {
            player.Move(2);
            player.Use(0);
            player.Move(2, 2, 1);
            Assert.AreEqual(floor.StairPosition, player.Position);
        }

        [Test]
        public void Test_EnemiesMove() {
            var enemy = floor.GetEnemy(6, 4);
            player.Move(2);
            Assert.AreEqual((5, 5), enemy.Position);

        }
    }
}
