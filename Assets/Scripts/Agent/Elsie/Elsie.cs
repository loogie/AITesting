using UnityEngine;
using System.Collections;

public class Elsie : Controller
{
    public GameObject house;
    public GameObject kitchen;
    public GameObject bed;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        wants.Add("eat", 0.0f);
        wants.Add("rest", 0.0f);
        wants.Add("clean", 0.0f);
        wants.Add("cook", 0.0f);
    }
    
}
