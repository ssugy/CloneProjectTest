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
            // ��ü��� 1(�Ϲ� material) : �̷��� ���� ��ȯ�ϸ�, �� ��ü �ϳ��� shader�� ����ȴ�.
            myRenderer.material.shader = Shader.Find("Mobile/Diffuse");

            // SharedMaterial�� ��� ������ shader�� ����ϰ� �ִ� ��ü�� ��ΰ� �Ѳ����� ����ȴ�.
            myRenderer.sharedMaterial.shader = Shader.Find("Mobile/Diffuse");

        }
    }
}
