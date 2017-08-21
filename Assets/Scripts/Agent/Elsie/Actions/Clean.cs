using UnityEngine;
using System.Collections;

public class Clean : Action
{
    public GameObject house;
    public float duration;

    private IEnumerator coroutine;

    public Clean(GameObject house, float duration)
    {
        this.house = house;
        this.duration = duration;

        coroutine = clean(duration);
    }

    IEnumerator clean(float d)
    {
        yield return new WaitForSeconds(d);
        print("House Cleaned!");
        Abort();
    }

    public override void Run()
    {
        base.Run();

        StartCoroutine(coroutine);
    }
}
