using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Controller : MonoBehaviour {

    public bool isRunning = false;
    public float behaviourInterval = 2.0f;

    protected Sequence root;
    protected Coroutine behaviourCoroutine;

    public Dictionary<string, float> wants;

    // Use this for initialization
    protected virtual void Start()
    {
        isRunning = true;
        root = new Sequence();

        wants = new Dictionary<string, float>();

        behaviourCoroutine = StartCoroutine(behaviour(behaviourInterval));
	}

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    IEnumerator behaviour(float delay)
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(delay);
            root.Resolve();
        }
    }
}
