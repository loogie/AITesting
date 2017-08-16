using UnityEngine;
using System.Collections.Generic;

public abstract class Composite : ILeaf
{
    public List<ILeaf> children;
    public Composite()
    {
        children = new List<ILeaf>();
    }

    public void AddChild(ILeaf child)
    {
        children.Add(child);
    }

    public void RemoveChild(ILeaf child)
    {
        children.Remove(child);
    }

    public abstract bool Resolve();
}
