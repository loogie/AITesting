using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WorkAction : DoAction
{

    public WorkAction(GameObject agent): base("Work", agent)
    {
    }

    public override bool Resolve()
    {
        AIController aic = agent.GetComponent<AIController>();
        return aic.DoAction("Work", new Work(agent, 0.1f));
    }
}