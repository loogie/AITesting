using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : ILeaf
{
    GameObject agent;
    GameObject target;

    public MoveTo(GameObject agent, GameObject target)
    {
        this.agent = agent;
        this.target = target;
    }

    public bool Resolve()
    {
        Collider c = target.GetComponent<Collider>();

        if (c.bounds.Contains(agent.transform.position))
        {
            return true; //Person is at location
        }
        else
        {
            //start moving to location
            NavMeshAgent m_Agent = agent.GetComponent<NavMeshAgent>();
            m_Agent.destination = target.transform.position;

            return false;
        }

    }
}