using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Tests
{
    [TestClass()]
    public class RoboTests
    {
        Services robo = new Services(5, 5);

        [TestMethod()]
        public void PlaceTest()
        {
            robo.Place(0, 0, 0);
            Assert.AreEqual("0,0,NORTH", robo.Report());

            robo.Place(1, 0, 3);
            Assert.AreEqual("1,0,WEST", robo.Report());

            robo.Place(4, 4, 2);
            Assert.AreEqual("4,4,SOUTH", robo.Report());

            robo.Place(5, 6, 3);
            Assert.AreEqual("4,4,SOUTH", robo.Report());
        }

        [TestMethod()]
        public void MoveTest()
        {
            robo.Place(0, 0, 0);
            robo.Move();
            Assert.AreEqual("0,1,NORTH", robo.Report());

            robo.Move();
            robo.Move();
            Assert.AreEqual("0,3,NORTH", robo.Report());

            robo.TurnLeft();
            robo.Move();
            Assert.AreEqual("0,3,WEST", robo.Report());
        }

        [TestMethod()]
        public void LeftTest()
        {
            robo.Place(0, 0, 0);
            robo.TurnLeft();
            Assert.AreEqual("0,0,WEST", robo.Report());

            robo.TurnLeft();
            Assert.AreEqual("0,0,SOUTH", robo.Report());

            
            robo.TurnLeft();
            robo.Move();
            Assert.AreEqual("1,0,EAST", robo.Report());
            robo.TurnLeft();
        }

        [TestMethod()]
        public void RightTest()
        {
            robo.Place(0, 0, 0);
            robo.TurnRight();
            Assert.AreEqual("0,0,EAST", robo.Report());

            robo.TurnRight();
            robo.Move();
            Assert.AreEqual("0,0,SOUTH", robo.Report());

            robo.TurnRight();
            robo.Move();
            robo.Move();
            Assert.AreEqual("0,0,WEST", robo.Report());

            robo.TurnRight();
            robo.Move();
            robo.Move();
            Assert.AreEqual("0,2,NORTH", robo.Report());
        }

        [TestMethod()]
        public void ReportTest()
        {
            robo.Place(0, 0, 0);
            Assert.AreEqual("0,0,NORTH", robo.Report());

            robo.Place(1, 0, 3);
            Assert.AreEqual("1,0,WEST", robo.Report());
        }


    }
}