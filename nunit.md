# [NUnit](https://nunit.org)

## [Visutl Studio Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/test-explorer-faq) doesn't like tests with dynamic parts in their name.

> ⚠ It won't be possible to run such tests by using Test Explorer UI.

Here is an example code for this issue:

```csharp
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
```

And here is how it looks in Test Explorer UI (_dimmed test name with a blue exclamation icon_):

![Visual Studio Test Explorer](/img/nunit-1.png)

> ✅ In order to fix this issue you will need to remove dynamic parts from the test name (The random value of `dynamicY` from the above example). 