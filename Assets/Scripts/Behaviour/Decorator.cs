using UnityEngine;
using System.Collections;

public class Decorator : ILeaf
{
    public ILeaf child;

    public void AddChild(ILeaf child)
    {
        this.child = child;
    }

    public bool Resolve()
    {
        return child.Resolve();
    }
}

public class Inverter : ILeaf
{
    public ILeaf child;

    public void AddChild(ILeaf child)
    {
        this.child = child;
    }

    public bool Resolve()
    {
        return !child.Resolve();
    }
}
