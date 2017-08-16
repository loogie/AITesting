using UnityEngine;
using System.Collections;

public abstract class Action
{
    public GameObject agent;
    public string name;

    public Action(string name, GameObject agent)
    {
        this.agent = agent;
        this.name = name;
    }

    public abstract void Run();
}
