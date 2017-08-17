using UnityEngine;
using System.Collections;

public abstract class DoAction : ILeaf
{
    protected string actionName;
    protected GameObject agent;

    public DoAction(string actionName, GameObject agent)
    {
        this.actionName = actionName;
        this.agent = agent;
    }

    public abstract bool Resolve();
}
