using System    .Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_UV : MonoBehaviour
{
    new MeshRenderer renderer;
    float offsetIndex;
    private float timeCnt;
    public float effectSpeed = 5;
    Vector2 offsetX;
    Vector2 offsetY;

    public int colNum = 4;
    public int rowNum = 2;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        offsetIndex = 4;    // 왼쪽 위 부터 출력
        timeCnt = 0;
        //effectSpeed = 5;    //여기서 초기화하면 안됨, 외부변수로 빼놧기 때문임

        offsetX = new Vector2();
        offsetY = new Vector2();

        //고정값 - 고정값은 사실 start에서 값을 지정만 해두는게 좋을 것 같다.update에서 사용할 이유 없음.
        Vector2 scale = new Vector2(1.0f/colNum, 1.0f/rowNum);   // 이미지 하나
        renderer.material.SetTextureScale("_MainTex", scale);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 0.25단위로 움직이게 하고 싶은것.
        Vector2 offset = new Vector2(0.25f, 0.25f); //원래크기의 1/4크기 offset
        offset = offsetIndex * offset;
        renderer.material.SetTextureOffset("_MainTex", offset);
        if (offsetIndex >= 4)
        {
            offsetIndex = 0;
        }
        //offsetIndex += Time.deltaTime;  // 이렇게 하면 부드럽게 움직이니까 원하시는답이 아니였음.
        offsetIndex++;  //강사님이 생각한 정답. 이러면 너무 빠르지않나.
        */

        // 검기 이미지 흐르는 것 보여주기
        timeCnt += Time.deltaTime * effectSpeed;
        if (timeCnt >= 1)
        {
            timeCnt = 0;
            offsetIndex++;
        }

        if (offsetIndex >= colNum * rowNum)
        {
            offsetIndex = 0;
        }
        else
        {
            offsetX = (Vector2.right / colNum) * (offsetIndex % colNum);
            offsetY = (Vector2.up / rowNum) * (Mathf.Floor(offsetIndex / colNum));
            renderer.material.SetTextureOffset("_MainTex", offsetX + offsetY);
        }

        /*
        // 강사님 코드
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed -= 1f;
            offsetIndex++;
            if (offsetIndex >=totalFrameCount)
                offsetIndex = 0;
        }
        float u = offsetIndex / colNum;
        float v = offsetIndex % colNum;
        Vector2 offset = new Vector2(v * size.x,
                                    (1f - size.y) - u * size.y);
        renderer.material.SetTextureOffset("_MainTex", offset);
        renderer.material.SetTextureScale("_MainTex", size);
        */
    }

    float elapsed;
    int totalFrameCount = 8;
    Vector2 size = new Vector2(0.25f, 0.5f);
}
