using UnityEngine;
using System.Collections;

public class IsHighestNeed : ILeaf
{
    public string name;
    public GameObject agent;

    public IsHighestNeed(GameObject agent, string name)
    {
        this.name = name;
        this.agent = agent;
    }

    public bool Resolve()
    {
        AIController aic = agent.GetComponent<AIController>();

        float important = aic.wants[name];

        foreach(float val in aic.wants.Values)
        {
            if (important < val)
            {
                return false;
            }
        }
        return true;
    }
}
