using UnityEngine;
using System.Collections;

public class Rest : Action
{

    public Rest(GameObject agent):base("Rest", agent)
    {

    }

    public override void Run()
    {
        Debug.Log("Running action REST");
        agent.GetComponent<AIController>().wants["fatigue"] = 0f;
    }
}
