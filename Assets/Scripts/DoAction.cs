using UnityEngine;
using System.Collections;

public class DoAction : ILeaf
{
    string actionName;
    GameObject agent;
    float cost;

    public DoAction(string actionName, GameObject agent, float cost)
    {
        this.actionName = actionName;
        this.agent = agent;
        this.cost = cost;
    }

    public bool Resolve()
    {
        AIController aic = agent.GetComponent<AIController>();

        if (!aic.DoAction(actionName))
        {
            Debug.Log("Action " + actionName + " not found");
        }
        return true;
    }
}
