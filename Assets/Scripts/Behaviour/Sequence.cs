using UnityEngine;
using System.Collections.Generic;

public class Sequence : ILeaf
{
    public List<ILeaf> children;

    public Sequence()
    {
        children = new List<ILeaf>();
    }

    public void AddChild(ILeaf child)
    {
        this.children.Add(child);
    }

    public void RemoveChild(ILeaf child)
    {
        this.children.Remove(child);
    }

    public virtual bool Resolve()
    {
        for(int i = 0; i < children.Count; i++)
        {
            if (!children[i].Resolve())
            {
                return false;
            }
        }
        return true;
    }
}
