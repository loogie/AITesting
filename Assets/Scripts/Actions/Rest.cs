using UnityEngine;
using System.Collections;

public class Rest : Action
{
    float startTime;

    public Rest(GameObject agent) : base(agent)
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

        if (currentTime - startTime >= 5)
        {
            this.agent.GetComponent<AIComponent>().wants["rest"] = 0.0f;
        }
    }
}
