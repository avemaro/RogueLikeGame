using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Fei5
    {
        string[] data;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            data = new string[] {
                "◆◆◆◆◆◆◆◆◆",
                "◆　　　　　　　◆",
                "◆　　巻試杖　　◆",
                "◆◇◇◇◇◇◆　◆",
                "◆　　　ギ　　　◆",
                "◆　◆◇◇◇◆　◆",
                "◆　◆◇◇◇◆　◆",
                "◆　　　階　　　◆",
                "◆◆◆◆◆◆◆◆◆"
            };
        }

        [Test]
        public void Test_Fei5HasPrinted() {
            var floor = new Floor(data);
            var player = floor.Player;
            Assert.AreEqual(data, floor.PrintFloor());

        }
    }
}
