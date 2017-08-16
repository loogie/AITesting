using UnityEngine;
using System.Collections;

public class Work : Action
{
    public float cost;

    public Work(GameObject agent, float cost):base("Work", agent)
    {
        this.cost = cost;
    }

    public override void Run()
    {
        Debug.Log("Running action WORK");
        agent.GetComponent<AIController>().wants["fatigue"] += cost;
    }
}
