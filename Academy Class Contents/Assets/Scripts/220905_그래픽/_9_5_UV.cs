using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_5_UV : MonoBehaviour
{
    MeshRenderer renderer;
    int offsetIndex;
    float elapsed;
    int column;
    int row;
    int totalFrameCount;
    Vector2 size;   // 출력할 텍스처 상에서 한프레임의 크기
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        offsetIndex = 0;
        elapsed = 0;
        column = 4;
        row = 2;
        size.x = 1.0f / column;
        size.y = 1.0f / row;
        totalFrameCount = column * row;
    }
    public void TestOffset()
    {
        //Vector2 offset = new Vector2(0.25f* offsetIndex, 0.25f);
        //offset = offsetIndex * offset;
        //renderer.material.SetTextureOffset("_MainTex", offset);
        //if (offsetIndex >= 4)
        //{
        //    offsetIndex = 0;
        //}
        //offsetIndex++;
    }
    void Update()
    {
        // 출력되는 위치를 1초마다 증가
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed -= 1f;
            offsetIndex++;
            if (offsetIndex >= totalFrameCount)
                offsetIndex = 0;
        }
        float u = offsetIndex / column;
        float v = offsetIndex % column;
        Vector2 offset = new Vector2( v * size.x,
                                      (1f - size.y) - u * size.y);
        renderer.material.SetTextureOffset("_MainTex", offset);
        renderer.material.SetTextureScale("_MainTex", size);
    }
}
