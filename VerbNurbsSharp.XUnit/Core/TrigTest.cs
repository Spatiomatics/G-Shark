﻿using System;
using System.Collections.Generic;
using VerbNurbsSharp.Core;
using Xunit;
using Xunit.Abstractions;

namespace VerbNurbsSharp.XUnit.Core
{
    public class TrigTest
    {
        private readonly ITestOutputHelper _testOutput;

        public TrigTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void ThreePointsAreFlat_ReturnTrue()
        {
            Point p1 = new Point() { 0.0, 0.0, 0.0 };
            Point p2 = new Point() { 10.0, 0.0, 0.0 };
            Point p3 = new Point() { 5.0, 5.0, 0.0 };
            Point p4 = new Point() { -5.0, -15.0, 0.0 };
            List<Point> points = new List<Point>(){p1,p2,p3,p4};

            Assert.True(Trig.ArePointsCoplanar(points));
        }

        [Fact]
        public void RayClosestPoint_ReturnTheProjectPoint()
        {
            Ray ray = new Ray(new Point(){0,0,0},new Vector(){30,45,0});
            Point pt = new Point(){10,20,0};
            Point expectedPt = new Point(){ 12.30769230769231, 18.461538461538463, 0 };

            Point closestPt = Trig.RayClosestPoint(pt, ray);
            Assert.Equal(expectedPt, closestPt);
        }

        [Fact]
        public void DistanceToRay_ReturnTheDistance_Between_APointAndTheRay()
        {
            Ray ray = new Ray(new Point() { 0, 0, 0 }, new Vector() { 30, 45, 0 });
            Point pt = new Point() { 10, 20, 0 };
            double distanceExpected = 2.7735009811261464;

            double distance = Trig.DistanceToRay(pt, ray);
            _testOutput.WriteLine(distance.ToString());
            Assert.Equal(distanceExpected, distance);
        }
    }
}
