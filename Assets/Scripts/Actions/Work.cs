using UnityEngine;
using System.Collections;

public class Work : Action
{
    float startTime;

    public Work(GameObject agent) : base(agent)
    {

    }

    public override void Run()
    {
        this.isRunning = true;
        startTime = Time.realtimeSinceStartup;
    }

    public override void Update()
    {
        float currentTime = Time.realtimeSinceStartup;

        if (currentTime - startTime >= 2)
        {
            this.agent.GetComponent<AIComponent>().AddDesire("rest", 0.1f);
        }
    }
    
}
