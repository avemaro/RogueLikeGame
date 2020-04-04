using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Fei6
    {
        string[] data;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            data = new string[] {
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆",
                "◆　　　　　　罠　　　罠　　　　◆",
                "◆　　　　　　◇　◆　◇　◆　　◆",
                "◆　　　　　　罠　罠　罠　罠　　◆",
                "◆　　　試　　◆　◇　◆　◇　　◆",
                "◆マ　　眼　　　　罠　　　罠階　◆",
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆"
            };
        }

        [Test]
        public void Test_Fei6HasPrinted() {
            var floor = new Floor(data);

            string[] expected = {
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆",
                "◆　　　　　　　　　　　　　　　◆",
                "◆　　　　　　◇　◆　◇　◆　　◆",
                "◆　　　　　　　　　　　　　　　◆",
                "◆　　　試　　◆　◇　◆　◇　　◆",
                "◆マ　　眼　　　　　　　　　階　◆",
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆"
            };
            Assert.AreEqual(expected, floor.PrintFloor());
        }

        [Test]
        public void Test_EyeDropWorks() {
            var floor = new Floor(data);
            var player = floor.Player;

            player.Move(Direction.down);
            player.Use(0);

            string[] expected = {
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆",
                "◆　　　　　　罠　　　罠　　　　◆",
                "◆　　　　　　◇　◆　◇　◆　　◆",
                "◆　　　　　　罠　罠　罠　罠　　◆",
                "◆　　　　　　◆　◇　◆　◇　　◆",
                "◆マ　　試　　　　罠　　　罠階　◆",
                "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆"
            };
            Assert.AreEqual(expected, floor.PrintFloor());
        }
    }
}
