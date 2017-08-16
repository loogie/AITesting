using UnityEngine;
using System.Collections;

public class Sequence : Composite
{

    public override bool Resolve()
    {
        for (int i = 0; i < children.Count; i++)
        {
            if (!children[i].Resolve())
                return false;
        }

        return true;
    }
}
