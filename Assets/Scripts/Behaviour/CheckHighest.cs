using UnityEngine;
using System.Collections;

public class CheckHighest : Sequence
{
    string name;
    GameObject agent;
    public CheckHighest(GameObject agent, string name)
    {
        this.name = name;
        this.agent = agent;
    }

    public override bool Resolve()
    {
        AIComponent aic = agent.GetComponent<AIComponent>();

        float important = aic.wants[name];

        foreach (float val in aic.wants.Values)
        {
            if (important < val)
            {
                return true;
            }
        }

        for (int i = 0; i < children.Count; i++)
        {
            if (!children[i].Resolve())
            {
                return true;
            }
        }

        return false;
    }
}
