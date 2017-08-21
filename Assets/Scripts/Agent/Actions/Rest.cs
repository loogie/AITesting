using UnityEngine;
using System.Collections;

public class Rest : Action
{
    public float fatigueGain = 0.2f;
    public float delay = 3.0f;

    private IEnumerator coroutine;

    public override void Run()
    {
        base.Run();

        coroutine = workTime(delay);
        StartCoroutine(coroutine);
    }

    IEnumerator workTime(float delay)
    {
        print("Starting to Rest");
        yield return new WaitForSeconds(delay);
        agent.wants["rest"] = 0;
        print("Finished Resting!");
        Abort();
    }

    public override void Abort()
    {
        StopCoroutine(coroutine);
        base.Abort();
    }
}
