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
        offsetIndex = 4;    // ���� �� ���� ���
        timeCnt = 0;
        //effectSpeed = 5;    //���⼭ �ʱ�ȭ�ϸ� �ȵ�, �ܺκ����� ���J�� ������

        offsetX = new Vector2();
        offsetY = new Vector2();

        //������ - �������� ��� start���� ���� ������ �صδ°� ���� �� ����.update���� ����� ���� ����.
        Vector2 scale = new Vector2(1.0f/colNum, 1.0f/rowNum);   // �̹��� �ϳ�
        renderer.material.SetTextureScale("_MainTex", scale);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 0.25������ �����̰� �ϰ� ������.
        Vector2 offset = new Vector2(0.25f, 0.25f); //����ũ���� 1/4ũ�� offset
        offset = offsetIndex * offset;
        renderer.material.SetTextureOffset("_MainTex", offset);
        if (offsetIndex >= 4)
        {
            offsetIndex = 0;
        }
        //offsetIndex += Time.deltaTime;  // �̷��� �ϸ� �ε巴�� �����̴ϱ� ���Ͻô´��� �ƴϿ���.
        offsetIndex++;  //������� ������ ����. �̷��� �ʹ� �������ʳ�.
        */

        // �˱� �̹��� �帣�� �� �����ֱ�
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
        // ����� �ڵ�
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
