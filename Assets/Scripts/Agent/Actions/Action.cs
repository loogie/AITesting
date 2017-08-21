using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIComponent))]
public abstract class Action : MonoBehaviour
{
    public bool isActive = false;
    protected AIComponent agent;
    // Use this for initialization
    protected virtual void Start()
    {
        agent = GetComponent<AIComponent>();
    }

    public virtual void Run()
    {
        this.isActive = true;
    }

    protected virtual void Update() { }

    public virtual void Abort()
    {
        this.isActive = false;
    }
}
