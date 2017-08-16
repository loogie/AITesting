using UnityEngine;
using System.Collections;

public class Decorator : ILeaf
{
    public ILeaf child;

    public void AddChild(ILeaf child)
    {
        this.child = child;
    }

    public virtual bool Resolve()
    {
        if (!child.Resolve())
            return false;

        return true;
    }
}
