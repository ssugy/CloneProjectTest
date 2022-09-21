using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
1.GPUInstancing ����� ����ϴ� ���ӿ�����Ʈ�� ������ ���� ������ ����
���콺 ������ ��ư ������ GPUInstancing ����� ����ϴ� ���ӿ�����Ʈ�� �ν��Ͻ� �����ϰ� 
���콺�� ���ӿ�����Ʈ ���ý�(���콺���ʹ�ưŬ��) ������ ���ӿ�����Ʈ�� �÷��� ���������� �����ϴ� ���α׷� �ڵ� �ۼ�
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
            // ���콺 �� ���α׷� �ڵ� �ۼ�
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
