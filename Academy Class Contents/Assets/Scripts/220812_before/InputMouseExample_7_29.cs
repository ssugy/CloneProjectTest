using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseExample_7_29 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 왼쪽 버튼 누름 = " + Input.mousePosition);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("마우스 오른쪽 버튼 누름");
        }
        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("마우스 휠 버튼 누름");
        }
    }
}
