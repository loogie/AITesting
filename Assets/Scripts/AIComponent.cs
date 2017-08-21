using UnityEngine;
using System;
using System.Collections;

public class AIComponent : Controller
{
    
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        
        wants.Add("work", 0.5f);
        wants.Add("rest", 0f);

        root = new Sequence();

        Inverter toWork = new Inverter();
        Sequence workSteps = new Sequence(
            new IsHighestNeed(this.gameObject, "work"),
            new MoveTo(this.gameObject, "WorkArea"),
            new DoWork(this.gameObject));
        toWork.AddChild(workSteps);

        Inverter toRest = new Inverter();
        Sequence restSteps = new Sequence(
            new IsHighestNeed(this.gameObject, "rest"),
            new MoveTo(this.gameObject, "RestArea"),
            new DoRest(this.gameObject));
        toRest.AddChild(restSteps);
        
        root.AddChild(toRest);
        root.AddChild(toWork);
    }

    // Update is called once per frame
    protected override void Update()
    {
    }

    public void AddDesire(string want, float ammt)
    {
        this.wants[want] += ammt;
    }
}
