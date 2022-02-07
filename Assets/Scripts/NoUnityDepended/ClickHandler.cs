using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickHandler
{
    readonly ISystemTimer _systemTimer;
    readonly List<DateTime> timedClicks = new List<DateTime>();

    readonly Dictionary<(int seconds, int clicks), Action> conditionDictionary =
        new Dictionary<(int seconds, int clicks), Action>();

    public ClickHandler(ISystemTimer systemTimer)
    {
        _systemTimer = systemTimer;
        systemTimer.StartTimer(CheckConditions);
    }

    public void ButtonClicked()
    {
        timedClicks.Add(DateTime.Now);
    }

    void CheckConditions()
    {
        //remove datetimes older than largest seen sec?

        //(int, int) clickTuple = new ValueTuple<int, int>(1, 1);

        //foreach (KeyValuePair<(int seconds, int clicks), Action> condition in conditionDictionary)
        //{
        //    foreach (DateTime click in timedClicks)
        //    {
        //        if ((_systemTimer.GetTime - click).TotalMilliseconds < condition.Key.seconds)
        //        {
        //            clickTuple.Item1 = condition.Key.seconds;
        //            clickTuple.Item2 += 1;
        //        }
        //    }
        //}


        //if (conditionDictionary.ContainsKey(clickTuple))
        //{
        //    conditionDictionary[clickTuple]?.Invoke();
        //}
        Debug.Log("Check here");

        foreach (DateTime click in timedClicks.Where(click => (_systemTimer.GetTime - click).TotalMilliseconds > 2000))
        {
            timedClicks.Remove(click);
        }

        int clickCount = timedClicks.Count;

        if (conditionDictionary.ContainsKey((2000, clickCount)))
        {
            conditionDictionary[(2000, clickCount)]?.Invoke();
        }

        if (conditionDictionary.ContainsKey((5000, clickCount)))
        {
            conditionDictionary[(5000, clickCount)]?.Invoke();
        }
    }

    public void AddColorCondition(int milliseconds, int clicks, Action onConditionMet)
    {
        conditionDictionary[(milliseconds, clicks)] = onConditionMet;
    }
}