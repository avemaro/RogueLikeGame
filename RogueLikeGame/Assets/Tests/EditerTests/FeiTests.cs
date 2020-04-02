using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FeiTests
    {
        string[] fei1;

        [OneTimeSetUp]
        public void FeiSetup() {
            fei1 = new string[] {
                "◆◆◆◆◆◆◆◆◆◆◆",
                "◆　　　◇　◇　◇　◆",
                "◆　試　　◆　◆　◇◆",
                "◆　　　◇　　　◇　◆",
                "◆◇　◆　◇◆◇　◇◆",
                "◆　◇　◇　◇　◇　◆",
                "◆◇　◇◆◇　◆　◇◆",
                "◆　◇　　　◇　　　◆",
                "◆◇　◆　◆　　階　◆",
                "◆　◇　◇　◇　　　◆",
                "◆◆◆◆◆◆◆◆◆◆◆"
            };
        }

        //[Test]
        //public void Test_Fei1() {
        //    var floor = new Floor("Fei1");

        //}

        [Test]
        public void DangeonDataHasLoaded() {
            var floor = new Floor(fei1);
            Assert.AreEqual(TerrainType.wall, floor.GetTerrain(0, 0));
            Assert.AreEqual(TerrainType.land, floor.GetTerrain(1, 1));
            Assert.AreEqual(TerrainType.water, floor.GetTerrain(4, 1));
            Assert.AreEqual(TerrainType.stair, floor.GetTerrain(8, 8));
            Assert.AreEqual((2, 2), floor.player.Position);
            floor.PrintFloor();
        }


    }
}
