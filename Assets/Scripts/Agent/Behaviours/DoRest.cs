using UnityEngine;
using System.Collections;

public class DoRest : DoAction
{
    public DoRest(GameObject agent) : base(agent)
    {

    }

    public override bool Resolve()
    {
        Rest rest = agent.GetComponent<Rest>();

        if (!rest.isActive)
            rest.Run();

        return false;
    }
}
