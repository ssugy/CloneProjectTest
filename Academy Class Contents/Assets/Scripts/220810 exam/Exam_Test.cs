using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        Vector3 tmp = transform.localEulerAngles;
        tmp.x = tmp.x + y * Time.deltaTime * 80;
        tmp.y = tmp.y + x * Time.deltaTime * 80;
        transform.localEulerAngles = tmp;
    }
}
