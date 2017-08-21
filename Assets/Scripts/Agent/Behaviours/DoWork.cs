using UnityEngine;
using System.Collections;

public class DoWork : DoAction
{
    public DoWork(GameObject agent) : base(agent)
    {

    }

    public override bool Resolve()
    {
        Work work = agent.GetComponent<Work>();

        if (!work.isActive)
            work.Run();

        return false;
    }
}
