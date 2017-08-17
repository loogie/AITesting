using UnityEngine;
using System.Collections;

public class Inverter : Decorator
{
    public override bool Resolve()
    {
        return !this.child.Resolve();
    }
}
