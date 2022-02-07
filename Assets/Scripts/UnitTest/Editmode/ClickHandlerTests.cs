using System;
using NUnit.Framework;

public class ClickHandlerTests
{
    StubSystemTimer _stubSystemTimer;
    ClickHandler click;

    [SetUp]
    public void Setup()
    {
        _stubSystemTimer = new StubSystemTimer();
        click = new ClickHandler(_stubSystemTimer);
    }

    [Test]
    public void ChangesIfClickedOnce()
    {
        string stringValue = "";
        DateTime now = DateTime.Now;
        click.AddColorCondition(2000, 1, () => stringValue = "Once");
        click.ButtonClicked();
        _stubSystemTimer.GetTime = now.AddSeconds(1);
        _stubSystemTimer.InvokeTimeUpdate();
        Assert.AreEqual("Once", stringValue);
    }

    [Test]
    public void ChangesIfClickedTwice()
    {
        string stringValue = "";
        DateTime now = DateTime.Now;
        int clickedTimes = 2;
        click.AddColorCondition(2000, clickedTimes, () => stringValue = "Twice");
        for (int i = 0; i < clickedTimes; i++)
        {
            click.ButtonClicked();
        }

        _stubSystemTimer.GetTime = now.AddSeconds(1);
        _stubSystemTimer.InvokeTimeUpdate();
        Assert.AreEqual("Twice", stringValue);
    }

    [Test]
    public void ChangesIfClickedFiveTimes()
    {
        string stringValue = "";
        DateTime now = DateTime.Now;
        int clickedTimes = 5;
        click.AddColorCondition(2000, clickedTimes, () => stringValue = "Five");
        for (int i = 0; i < clickedTimes; i++)
        {
            click.ButtonClicked();
        }

        _stubSystemTimer.GetTime = now.AddSeconds(1);
        _stubSystemTimer.InvokeTimeUpdate();
        Assert.AreEqual("Five", stringValue);
    }

    [Test]
    public void NoChangeIfClickedNoTimes()
    {
        string stringValue = "";
        DateTime now = DateTime.Now;
        int clickedTimes = 1;
        click.AddColorCondition(2000, clickedTimes, () => stringValue = "ZeroTimes");
        _stubSystemTimer.GetTime = now.AddSeconds(1);
        _stubSystemTimer.InvokeTimeUpdate();
        Assert.AreEqual("", stringValue);
    }

    [Test]
    public void NoChangeIfClickeDifferentTimes()
    {
        string stringValue = "";
        DateTime now = DateTime.Now;
        int clickedTimes = 5;
        int exptectedTimes = 1;
        click.AddColorCondition(2000, exptectedTimes, () => stringValue = "WrongTimes");
        for (int i = 0; i < clickedTimes; i++)
        {
            click.ButtonClicked();
        }

        _stubSystemTimer.GetTime = now.AddSeconds(1);
        _stubSystemTimer.InvokeTimeUpdate();
        Assert.AreEqual("", stringValue);
    }
}