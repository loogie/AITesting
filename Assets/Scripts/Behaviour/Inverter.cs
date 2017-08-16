using UnityEngine;
using System.Collections;

public class Inverter : Decorator
{
    public override bool Resolve()
    {
        Debug.Log(this.child.ToString());
        return !this.child.Resolve();
    }
}
