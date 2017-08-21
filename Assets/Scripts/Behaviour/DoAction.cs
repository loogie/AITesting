using UnityEngine;
using System.Collections;

public abstract class DoAction : ILeaf
{
    protected GameObject agent;

    public DoAction(GameObject agent)
    {
        this.agent = agent;
    }

    public abstract bool Resolve();
}
