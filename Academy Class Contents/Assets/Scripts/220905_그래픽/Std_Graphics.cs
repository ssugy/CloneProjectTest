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
        // 메인텍스처 이미지 변경
        //planeRenderer.material.mainTexture = 넣을이미지
        //laneRenderer.material.SetTexture("_MainTex", 넣을이미지);
        
        // offset변경 (이것도 set함수가 존재한다)
        planeRenderer.material.mainTextureOffset += Vector2.up * Time.deltaTime;
    }
}
