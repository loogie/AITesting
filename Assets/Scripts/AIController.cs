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

    public string currentAction;
    public Dictionary<string, float> wants;

    public Sequence root;

    private void Start()
    {

        wants = new Dictionary<string, float>();
        wants.Add("fatigue", fatigue);
        wants.Add("work", 0.5f);

        
        Sequence tired = new Sequence();
        tired.AddChild(new IsHighestNeed(this.gameObject, "fatigue"));
        tired.AddChild(new MoveAction(this.gameObject, GameObject.Find("RestArea")));
        tired.AddChild(new RestAction(this.gameObject));

        Inverter runTired = new Inverter();
        runTired.AddChild(tired);

        Sequence work = new Sequence();
        work.AddChild(new IsHighestNeed(this.gameObject, "work"));
        work.AddChild(new MoveAction(this.gameObject, GameObject.Find("WorkArea")));
        work.AddChild(new WorkAction(this.gameObject));

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

    public bool DoAction(string actionName, Action action)
    {
        if (currentAction == actionName)
        {
            return false;
        }

        currentAction = actionName;
        action.Run();

        return true;
    }
}
