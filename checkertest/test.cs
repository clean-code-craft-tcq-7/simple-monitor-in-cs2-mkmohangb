namespace checkertest;

using Xunit;
using checkerlib;
using Moq;
public class CheckerTests
{
    [Fact]
    public void NotOkWhenAnyVitalIsOffRange()
    {
        var mockDisplay = new Mock<ICheckerDisplay>();
        var checker = new Checker(mockDisplay.Object);

        Assert.False(Checker.VitalsOk(99f, 102, 70));
        mockDisplay.Verify(d => d.DisplayVitalsAlert("Pulse Rate is out of range!"), Times.Once);

        mockDisplay.Reset();
        Assert.True(Checker.VitalsOk(98.1f, 70, 98));
        mockDisplay.Verify(d => d.DisplayVitalsAlert(It.IsAny<string>()), Times.Never);
    }
}