using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Graphics : MonoBehaviour
{
    public Renderer planeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����ؽ�ó �̹��� ����
        //planeRenderer.material.mainTexture = �����̹���
        //laneRenderer.material.SetTexture("_MainTex", �����̹���);
        
        // offset���� (�̰͵� set�Լ��� �����Ѵ�)
        planeRenderer.material.mainTextureOffset += Vector2.up * Time.deltaTime;
    }
}
