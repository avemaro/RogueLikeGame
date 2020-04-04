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

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            data = new string[] {
                "◆◆◆◆◆◆◆◆◆",
                "◆Ｇ     Ｇ◆",
                "◆　武ＧマＧギ　◆",
                "◆Ｇ武　マ　ギＧ◆",
                "◆　武　マ　ギ　◆",
                "◆　Ｇ　　　Ｇ　◆",
                "◆　◇◇◇◇◇階◆",
                "◆Ｇ　試巻　　　◆",
                "◆◆◆◆◆◆◆◆◆"
            };
        }

        [Test]
        public void Test_floorHasPrinted() {
            var floor = new Floor(data);
            Assert.AreEqual(data, floor.PrintFloor());
        }
    }
}
