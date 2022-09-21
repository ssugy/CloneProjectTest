using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
1.GPUInstancing 기능을 사용하는 게임오브젝트의 색상을 게임 실행중 변경
마우스 오른쪽 버튼 누를시 GPUInstancing 기능을 사용하는 게임오브젝트의 인스턴스 생성하고 
마우스로 게임오브젝트 선택시(마우스왼쪽버튼클릭) 선택한 게임오브젝트의 컬러를 검정색으로 변경하는 프로그램 코드 작성
 */
public class _9_20_Practice_GPUInsancing : MonoBehaviour
{
    GameObject rcTestObject;
    MaterialPropertyBlock tmpProps;
    private void Awake()
    {
        tmpProps = new MaterialPropertyBlock();
        rcTestObject = Resources.Load<GameObject>("Sphere");
    }
    public void Spawn()
    {
        GameObject createObject = GameObject.Instantiate<GameObject>(rcTestObject);
        //MaterialPropertyBlock props = new MaterialPropertyBlock();
        //Renderer renderer = createObject.GetComponent<MeshRenderer>();
        //props.SetColor("_Color", new Color(1f, 1f, 1f));
        //renderer.SetPropertyBlock(props);
        createObject.transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Spawn();
        }
        if(Input.GetMouseButtonDown(0))
        {
            // 마우스 픽 프로그램 코드 작성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                MeshRenderer renderer =  hitInfo.collider.gameObject.GetComponent<MeshRenderer>();
                if(renderer != null)
                {
                    renderer.GetPropertyBlock(tmpProps);
                    tmpProps.SetColor("_Color", new Color(0, 0, 0, 0.3f));
                    renderer.SetPropertyBlock(tmpProps);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }
}
