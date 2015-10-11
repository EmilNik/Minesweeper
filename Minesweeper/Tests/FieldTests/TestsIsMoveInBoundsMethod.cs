﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace FieldTests
{
    [TestClass]
    public class TestsIsMoveInBoundsMethod
    {
            string[,] testMineFiled = new string[5, 10];
            IField mineFieldTest = new Minesweeper.Field(5, 10, 15);

        //Positive tests
        [TestMethod]
        public void TetsIsMoveInBoundsPossitiveEdgeOne()
        {
            var output = mineFieldTest.IsMoveInBounds(0,0);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsPossitiveEdgeTwo()
        {
            var output = mineFieldTest.IsMoveInBounds(4,9);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsPossitiveEdgeThree()
        {
            var output = mineFieldTest.IsMoveInBounds(0, 9);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsPossitiveEdgeFour()
        {
            var output = mineFieldTest.IsMoveInBounds(4, 0);
            Assert.AreEqual(true, output);
        }

        //Negative tests

        [TestMethod]
        public void TetsIsMoveInBoundsNegativeEdgeOne()
        {
            var output = mineFieldTest.IsMoveInBounds(-1, 0);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsNegativeEdgeTwo()
        {
            var output = mineFieldTest.IsMoveInBounds(-1,-1);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsNegativeEdgeThree()
        {
            var output = mineFieldTest.IsMoveInBounds(-1, 9);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsNegativeEdgeFour()
        {
            var output = mineFieldTest.IsMoveInBounds(0,10);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void TetsIsMoveInBoundsNegativeEdgeFife()
        {
            var output = mineFieldTest.IsMoveInBounds(5, 0);
            Assert.AreNotEqual(true, output);
        }

        //Test With Extreme numbe
        [TestMethod]
        public void TetsIsMoveInBoundsNegativeExtremeNumber()
        {
            var output = mineFieldTest.IsMoveInBounds(2000000, 5000000);
            Assert.AreNotEqual(true, output);
        }
    }

}
