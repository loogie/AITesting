using UnityEngine;
using System.Collections;

public class Cook : Action
{
    public GameObject target;
    public float duration;

    private IEnumerator coroutine;

    public Cook(GameObject target, float duration)
    {
        this.target = target;
        this.duration = duration;

        coroutine = clean(duration);
    }

    IEnumerator clean(float d)
    {
        yield return new WaitForSeconds(d);
        print("Food Cooked!");
        Abort();
    }

    public override void Run()
    {
        base.Run();

        StartCoroutine(coroutine);
    }
}
