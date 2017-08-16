using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float fatigue = 0f;
    [Range(0.0f, 1.0f)]
    public float work = 0.5f;

    private Dictionary<string, Action> actions;
    public Dictionary<string, float> wants;

    public Sequence root;

    private void Start()
    {
        actions = new Dictionary<string, Action>();
        actions.Add("Work", new Work(this.gameObject, 0.1f));
        actions.Add("Rest", new Rest(this.gameObject));

        wants = new Dictionary<string, float>();
        wants.Add("fatigue", fatigue);
        wants.Add("work", 0.5f);

        
        Sequence tired = new Sequence();
        tired.AddChild(new IsHighestNeed(this.gameObject, "fatigue"));
        tired.AddChild(new MoveTo(this.gameObject, GameObject.Find("RestArea")));
        tired.AddChild(new DoAction("Rest", this.gameObject, 0));

        Inverter runTired = new Inverter();
        runTired.AddChild(tired);

        Sequence work = new Sequence();
        work.AddChild(new IsHighestNeed(this.gameObject, "work"));
        work.AddChild(new MoveTo(this.gameObject, GameObject.Find("WorkArea")));
        work.AddChild(new DoAction("Work", this.gameObject, 0.1f));

        Inverter runWork = new Inverter();
        runWork.AddChild(work);

        root = new Sequence();
        root.AddChild(runTired);
        root.AddChild(runWork);

    }

    private void Update()
    {
        root.Resolve();
    }

    public bool DoAction(string actionName)
    {
        if (this.actions.ContainsKey(actionName))
        {
            this.actions[actionName].Run();
            return true;
        }
        else
        {
            return false;
        }
    }
}
