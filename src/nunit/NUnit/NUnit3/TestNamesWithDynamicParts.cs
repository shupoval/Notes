using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnit3
{
    public class TestNamesWithDynamicParts
    {
        [TestCaseSource(nameof(GetDynamicTestCaseData))]
        public void SumTestCases(int x, int y, int sum)
        {
            var actualSum = x + y;
            Assert.AreEqual(sum, actualSum);
        }

        public static IEnumerable<TestCaseData> GetDynamicTestCaseData()
        {
            var dynamicY = new Random().Next(100);
            return
                new[]
                {
                    new TestCaseData(0, 1, 1).SetArgDisplayNames("Test Case Name without dynamic parts"),
                    new TestCaseData(0, dynamicY, dynamicY).SetArgDisplayNames($"Test Case Name with dynamic part {nameof(dynamicY)}='{dynamicY}'")
                };
        }
    }
}