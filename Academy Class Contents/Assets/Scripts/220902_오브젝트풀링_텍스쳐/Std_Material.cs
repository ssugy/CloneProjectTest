using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Material : MonoBehaviour
{
    public GameObject Cube;
    Texture rcTexture;
    Texture rcSword;
    Vector2 textureOffset;
    MeshRenderer cubeMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rcTexture = Resources.Load<Texture2D>("TrollGiant");
        rcSword = Resources.Load<Texture2D>("Longsword");

        cubeMeshRenderer = Cube.GetComponent<MeshRenderer>();
        textureOffset = cubeMeshRenderer.material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            //Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcTexture);
            Cube.GetComponent<MeshRenderer>().material.mainTexture = rcTexture;
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            //Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcSword);   // 방법1: 함수를 이용해서 텍스쳐 변경
            Cube.GetComponent<MeshRenderer>().material.mainTexture = rcSword;               // 방법2: 프로퍼티를 이용한 텍스쳐 변경
        }
        textureOffset.Set(textureOffset.x + Time.deltaTime, textureOffset.y);  // 이거는 vector2에있는 set을 한것임.
        cubeMeshRenderer.material.mainTextureOffset = textureOffset;
    }
}
