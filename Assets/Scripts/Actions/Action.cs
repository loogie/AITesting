using UnityEngine;
using System.Collections;

public abstract class Action
{
    public bool isRunning;
    protected GameObject agent;

    public Action(GameObject agent)
    {
        this.agent = agent;
        this.isRunning = false;
    }

    public abstract void Update();

    public abstract void Run();

    public virtual void Abort()
    {
        if (this.isRunning)
        {
            this.isRunning = false;
        }
    }
}
