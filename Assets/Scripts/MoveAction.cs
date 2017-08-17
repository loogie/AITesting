using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveAction: DoAction
{
    GameObject target;

    public MoveAction(GameObject agent, GameObject target): base("Move", agent)
    {
        this.target = target;
    }

    public override bool Resolve()
    {
        AIController aic = agent.GetComponent<AIController>();
        return aic.DoAction("Move_" + target.name, new Move(agent, target, 0.01f));
    }
}