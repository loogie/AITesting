using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Move : Action
{
    public GameObject target;
    public float cost;

    public Move(GameObject agent, GameObject target, float cost):base("Work", agent)
    {
        this.cost = cost;
        this.target = target;
    }

    public override void Run()
    {
        NavMeshAgent m_agent = agent.GetComponent<NavMeshAgent>();
        m_agent.destination = this.target.transform.position;
        agent.GetComponent<AIController>().wants["fatigue"] += cost;
    }
}
