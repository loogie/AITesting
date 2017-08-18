using UnityEngine;
using System.Collections;

public abstract class DoAction : ILeaf
{
    protected GameObject agent;

    public DoAction(GameObject agent)
    {
        this.agent = agent;
    }

    public abstract bool Resolve();
}

public class DoWork : DoAction
{
    public DoWork(GameObject agent) : base(agent)
    {

    }

    public override bool Resolve()
    {
        this.agent.GetComponent<AIComponent>().DoAction(new Work(agent));
        return true;
    }
}

public class DoRest : DoAction
{
    public DoRest(GameObject agent) : base(agent)
    {

    }

    public override bool Resolve()
    {
        this.agent.GetComponent<AIComponent>().DoAction(new Rest(agent));
        return true;
    }
}

public class MoveTo : DoAction
{
    GameObject target;

    public MoveTo(GameObject agent, string targetName):base(agent){
        this.target = GameObject.Find(targetName);
    }

    public override bool Resolve()
    {
        Collider c = target.GetComponent<Collider>();
        if (c.bounds.Contains(agent.transform.position))
        {
            return true;
        }
        else
        {
            this.agent.GetComponent<AIComponent>().MoveTo(target.name);
            return false;
        }
    }
}
