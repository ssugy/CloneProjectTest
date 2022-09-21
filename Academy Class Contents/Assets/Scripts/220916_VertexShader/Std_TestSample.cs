using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_TestSample : MonoBehaviour
{
    //public GameObject cube;
    //private Std_Cube cubeScript;

    //public Std_Cube cubeScript2;
    //private void Start()
    //{
    //    cube.name = "큐브";
    //    cubeScript = cube.GetComponent<Std_Cube>();
    //    cubeScript.함수_퍼블릭();

    //    cubeScript2.함수_퍼블릭();
    //}

    public Std_StaticDoorButton btn;
    public Std_StaticDoorButton btn2;
    public Std_StaticDoorButton btn3;
    public Std_StaticDoorButton btn4;

    private void Awake()
    {
        Std_StaticDoorButton.instance.num = 100;
        
        btn.num2 = 100;

        Debug.Log(btn2.num2);
    }
}
