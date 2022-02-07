using System;
using System.Timers;
using UnityEngine;

public interface ISystemTimer
{
    DateTime GetTime { get; }
    void StartTimer(Action onUpdate);
}

public class DefaultSystemTimer : ISystemTimer
{
    Action onUpdate;

    public void StartTimer(Action onUpdate)
    {
        Timer time = new Timer(10);
        this.onUpdate += onUpdate;
        time.Elapsed += OnUpdate;
        time.AutoReset = true;
        time.Enabled = true;
    }

    public DateTime GetTime => DateTime.Now;

    void OnUpdate(object sender, ElapsedEventArgs e)
    {
        onUpdate?.Invoke();
    }
}

public class StubSystemTimer : ISystemTimer
{
    Action onUpdate;

    public void StartTimer(Action onUpdate)
    {
        this.onUpdate = onUpdate;
    }

    public DateTime GetTime { get; set; }


    public void InvokeTimeUpdate()
    {
        onUpdate?.Invoke();
    }
}
public class RegularTimer : MonoBehaviour, ISystemTimer
{
    Action onUpdate;
    public DateTime GetTime { get; }
    public void StartTimer(Action onUpdate)
    {
        this.onUpdate += onUpdate;
    }

    void Update()
    {
        onUpdate?.Invoke();
    }
}