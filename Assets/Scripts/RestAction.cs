using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RestAction : DoAction
{

    public RestAction(GameObject agent): base("Rest", agent)
    {
    }

    public override bool Resolve()
    {
        AIController aic = agent.GetComponent<AIController>();
        return aic.DoAction("Rest", new Rest(agent));
    }
}