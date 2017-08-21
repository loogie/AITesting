using UnityEngine;
using System.Collections;

public class MoveTo : DoAction
{
    GameObject target;

    public MoveTo(GameObject agent, string targetName) : base(agent)
    {
        this.target = GameObject.Find(targetName);
    }

    public override bool Resolve()
    {
        if (target.GetComponent<Collider>().bounds.Contains(agent.transform.position))
        {
            return true;
        }
        else
        {
            Move m = this.agent.GetComponent<Move>();
            m.target = target;

            if (!m.isActive)
                m.Run();

            return false;
        }
    }
}
