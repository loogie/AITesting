using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Move : Action
{
    GameObject target;
    NavMeshAgent m_agent;

    public Move(GameObject agent, GameObject target) : base(agent)
    {
        this.target = target;
        m_agent = agent.GetComponent<NavMeshAgent>();
    }

    public override void Abort()
    {
        this.m_agent.destination = agent.transform.position;
        this.isRunning = false;
    }

    public override void Run()
    {
        this.isRunning = true;
        this.m_agent.destination = target.transform.position;
    }

    public override void Update()
    {
        Collider c = target.GetComponent<Collider>();
        if (c.bounds.Contains(agent.transform.position))
        {
            agent.GetComponent<AIComponent>().currentAction = null;
            this.isRunning = false;
        }
    }
}
