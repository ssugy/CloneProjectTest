using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Std_ChangeShader : MonoBehaviour
{
    MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 교체방법 1(일반 material) : 이렇게 직접 변환하면, 이 객체 하나만 shader가 변경된다.
            myRenderer.material.shader = Shader.Find("Mobile/Diffuse");

            // SharedMaterial의 경우 동일한 shader를 사용하고 있는 객체들 모두가 한꺼번에 변경된다.
            myRenderer.sharedMaterial.shader = Shader.Find("Mobile/Diffuse");

        }
    }
}
