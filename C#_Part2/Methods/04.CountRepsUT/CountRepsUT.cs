using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CountRepsUT
{
    [TestMethod]
    public void TestEmptyArr()
    {
        int result = CountRepsOfNumInArr.CountReps(2, new int[] { });
        Assert.AreEqual(result, 0);
    }

    [TestMethod]
    public void TestFirstAndLastElem()
    {
        int result = CountRepsOfNumInArr.CountReps(2, new int[] { 2, 3, 3, 3, 2, 2, 5, 9, 2 });
        Assert.AreEqual(result, 4);
    }

    [TestMethod]
    public void TestNoReps()
    {
        int result = CountRepsOfNumInArr.CountReps(2, new int[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 1, 1 });
        Assert.AreEqual(result, 0);
    }

    [TestMethod]
    public void TestMaxValue()
    {
        int result = CountRepsOfNumInArr.CountReps(int.MaxValue, new int[] { int.MaxValue, int.MinValue, 2, 4, 7, 1, -100, int.MaxValue });
        Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void TestMinValue()
    {
        int result = CountRepsOfNumInArr.CountReps(int.MinValue, new int[] { int.MinValue, int.MinValue, 2, 4, int.MaxValue, 1, -100, int.MaxValue });
        Assert.AreEqual(result, 2);
    }
}