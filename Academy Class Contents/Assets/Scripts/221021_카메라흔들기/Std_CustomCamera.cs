using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_CustomCamera : MonoBehaviour
{
    Do doSomething;
    public float duration;
    float tmpDuration;
    Vector3 origin;
    public float rangeConstant;
    private void Start()
    {
        tmpDuration = duration;
    }

    public void OnEffect()
    {
        tmpDuration -= Time.deltaTime;
        Vector3 delta = new Vector3(Random.Range(-1.0f, 1f) * rangeConstant, Random.Range(-0.25f, 0.25f) * rangeConstant, 0);
        transform.position = origin + delta;
        if (tmpDuration <= 0)
        {
            doSomething -= OnEffect;
            tmpDuration = duration;
            transform.position = origin;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (doSomething != OnEffect)
            {
                origin = transform.position;
                doSomething = OnEffect;
            }
        }
        if (doSomething != null)
        {
            doSomething();
        }

    }
}
