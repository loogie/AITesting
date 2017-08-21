using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Move : Action
{
    public GameObject target;

    // Use this for initialization
    protected override void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isActive)
        {
            Collider c = target.GetComponent<Collider>();
            if (c.bounds.Contains(transform.position))
            {
                Abort();
            }
        }
    }

    public override void Run()
    {
        base.Run();

        NavMeshAgent nma = gameObject.GetComponent<NavMeshAgent>();
        nma.SetDestination(target.transform.position);
        nma.isStopped = false;
    }

    public override void Abort()
    {
        NavMeshAgent nma = gameObject.GetComponent<NavMeshAgent>();
        nma.isStopped = true;
        base.Abort();
    }
}
