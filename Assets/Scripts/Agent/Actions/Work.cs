using UnityEngine;
using System.Collections;

public class Work : Action
{
    public float fatigueCost = 0.1f;
    public float delay = 1.5f;

    private Coroutine coroutine;

    public override void Run()
    {
        base.Run();
        coroutine = StartCoroutine(workTime(delay));
    }

    IEnumerator workTime(float delay)
    {
        print("Starting Work");
        yield return new WaitForSeconds(delay);
        agent.AddDesire("rest", fatigueCost);
        StopCoroutine(coroutine);
        Abort();
    }

    public override void Abort()
    {
        base.Abort();
    }
}
