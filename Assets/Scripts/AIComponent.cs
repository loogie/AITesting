using UnityEngine;
using System.Collections;

public class AIComponent : Controller
{
    bool running;
    Sequence root;
    public Action currentAction;

    public System.Collections.Generic.Dictionary<string, float> wants;

    // Use this for initialization
    protected override void Start()
    {
        running = true;

        wants = new System.Collections.Generic.Dictionary<string, float>();
        wants.Add("work", 0.5f);
        wants.Add("rest", 0f);

        root = new Sequence();

        Inverter toWork = new Inverter();
        Sequence workSteps = new Sequence();
        IsHighestNeed wihn = new IsHighestNeed(this.gameObject, "work");
        MoveTo mtw = new MoveTo(this.gameObject, "WorkArea");
        DoWork dw = new DoWork(this.gameObject);
        workSteps.AddChild(wihn);
        workSteps.AddChild(mtw);
        workSteps.AddChild(dw);
        toWork.AddChild(workSteps);

        Inverter toRest = new Inverter();
        Sequence restSteps = new Sequence();
        IsHighestNeed rihn = new IsHighestNeed(this.gameObject, "rest");
        MoveTo mtr = new MoveTo(this.gameObject, "RestArea");
        DoRest dr = new DoRest(this.gameObject);
        restSteps.AddChild(rihn);
        restSteps.AddChild(mtr);
        restSteps.AddChild(dr);
        toRest.AddChild(restSteps);
        
        root.AddChild(toWork);
        root.AddChild(toRest);

    }

    // Update is called once per frame
    protected override void Update()
    {
        root.Resolve();
    }

    IEnumerator runAction(Action action)
    {
        action.Run();
        while (action.isRunning)
        {
            Debug.Log(action.ToString() + " is running");
            action.Update();
            yield return null;
        }
    }

    public void AddDesire(string want, float ammt)
    {
        this.wants[want] += ammt;

        Debug.Log(want + " has new value of " + this.wants[want]);
    }

    public void DoAction(Action action)
    {
        currentAction = action;
        StartCoroutine(runAction(currentAction));
    }

    public void AbortAction()
    {
        if (currentAction != null)
        {
            currentAction.Abort();
            currentAction = null;
        }
    }

    public void MoveTo(string name)
    {
        currentAction = new Move(this.gameObject, GameObject.Find(name));
        StartCoroutine(runAction(currentAction));
    }
}
