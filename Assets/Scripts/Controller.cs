using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Controller : MonoBehaviour {

    NavMeshAgent m_agent;

    // Use this for initialization
    protected virtual void Start()
    {
        m_agent = gameObject.GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}
