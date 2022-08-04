using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticConstTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticConst.s_instance.num = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
