﻿using System.Collections;
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
        string[] fei2;

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

            fei2 = new string[] {
                "◆◆◆◆◆◆◆◆◆◆◆　　　　　",
                "◆　　　◆◆◆　　　◆　　　　　",
                "◆　　試☆☆☆　　　◆　　　　　",
                "◆　　　◆◆◆　　　◆　　　　　",
                "◆◆◆◆◆◆◆　　　◆　　　　　",
                "　　　　　　◆　　　◆　　　　　",
                "　　　　　　◆◆☆◆◆　　　　　",
                "　　　　　　　◆☆◆　　　　　　",
                "　　　　　　　◆☆◆　　　　　　",
                "　　　　　　　◆☆◆◆◆◆◆◆◆",
                "　　　　　　　◆☆☆☆☆☆☆☆◆",
                "　　　　　　　◆◆☆☆☆☆☆☆◆",
                "　　　　　　　◆◆☆☆☆☆☆◆◆",
                "　　　　　　　◆◆◆☆☆☆☆◆◆",
                "　　　　　　　◆◆◆☆☆☆◆◆◆",
                "　　　　　　　◆◆◆◆☆☆◆◆◆",
                "　　　　　　　◆◆◆◆階◆◆◆◆",
                "　　　　　　　◆◆◆◆◆◆◆◆◆"
            };
        }

        [Test]
        public void DangeonDataHasLoaded() {
            var floor = new Floor(fei1);
            Assert.AreEqual(TerrainType.wall, floor.GetTerrain(0, 0));
            Assert.AreEqual(TerrainType.land, floor.GetTerrain(1, 1));
            Assert.AreEqual(TerrainType.water, floor.GetTerrain(4, 1));
            Assert.AreEqual((8, 8), floor.StairPosition);
            Assert.AreEqual((2, 2), floor.Player.Position);
            floor.PrintFloor();
        }

        [Test]
        public void PlayerMoves() {
            var floor = new Floor(fei1);
            var player = floor.Player;

            Assert.True(player.Move(Direction.down));
            Assert.False(player.Move(Direction.downRight));
            Assert.True(player.Move(Direction.down));
            Assert.False(player.Move(Direction.downRight));
            Assert.True(player.Move(Direction.downLeft));
            Assert.AreEqual((1, 5), player.Position);
            floor.PrintFloor();
        }

        [Test]
        public void Test_Fei1() {
            var floor = new Floor(fei1);
            var player = floor.Player;

            int[] wrongMoves = new int[18];
            for (int i = 0; i < wrongMoves.Length; i++)
                wrongMoves[i] = Random.Range(0, 7);
            player.Move(DirectionExtend.GetDirections(wrongMoves));
            Assert.AreNotEqual((8, 8), player.Position);

            floor = new Floor(fei1);
            player = floor.Player;
            int[] correctMoves = { 4, 4, 5, 3, 3,
                                   2, 2, 1, 7, 7,
                                   1, 2, 2, 3, 3,
                                   5, 4, 4};
            player.Move(DirectionExtend.GetDirections(correctMoves));
            Assert.AreEqual(floor.StairPosition, player.Position);
        }

        [Test]
        public void Test_Fei2() {
            var floor = new Floor(fei2);
            var player = floor.Player;
            floor.PrintFloor();

            Assert.False(player.Move(Direction.right));
            player.Attack();
            floor.PrintFloor();
            Assert.True(player.Move(Direction.right));
            floor.PrintFloor();

            int[] moves = { 2, 2, 2, 3, 4, 4 };
            Assert.True(player.Move(DirectionExtend.GetDirections(moves)));
            player.Attack();
            floor.PrintFloor();

            moves = new int[] { 4, 4, 4, 4, 4};
            Assert.True(player.Move(DirectionExtend.GetDirections(moves)));
            player.Move(Direction.right);
            player.Attack();
            floor.PrintFloor();

            moves = new int[] { 2, 3, 3 };
            Assert.True(player.Move(DirectionExtend.GetDirections(moves)));
            player.Move(Direction.down);
            player.Attack();
            floor.PrintFloor();

            moves = new int[] { 4, 4, 4, 4};
            Assert.True(player.Move(DirectionExtend.GetDirections(moves)));
            Assert.AreEqual(floor.StairPosition, player.Position);
            floor.PrintFloor();
        }
    }
}
