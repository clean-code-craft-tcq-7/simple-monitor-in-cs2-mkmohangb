namespace checkertest;

using Xunit;
using checkerlib;
public class CheckerTests
{
    [Fact]
    public void NotOkWhenAnyVitalIsOffRange()
    {
        Assert.False(Checker.VitalsOk(99f, 102, 70));
        Assert.True(Checker.VitalsOk(98.1f, 70, 98));
    }
}