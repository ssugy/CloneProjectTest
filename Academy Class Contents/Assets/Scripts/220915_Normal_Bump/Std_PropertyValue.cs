using Newtonsoft.Json.Serialization;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class Std_PropertyValue : MonoBehaviour
{
    public MeshRenderer renderer;
    [Range(0, 1)] public float alpha;
    void Start()
    {
        renderer = GameObject.Find("brick_lambert").GetComponent<MeshRenderer>();
        renderer.material.SetFloat("_Alpha", alpha);
        hits = new List<RaycastHit>();
    }

    // �����Ϳ��� �� �ٲ𶧸��� ȣ���
    //private void OnValidate()
    //{
    //    // material���� �޸� �����ȴٰ� ���ϰ� sharedMaterial����� ��.
    //    renderer.sharedMaterial.SetFloat("_Alpha", alpha);
    //}

    // �÷��̾� �̵��ϸ� ȭ�� ������ ������ �ϱ�.
    public GameObject player;
    public Camera mainCamera;
    Ray ray;
    Vector3 dir;
    RaycastHit[] raycastHits;
    RaycastHit[] beforeRaycastHits;
    //int layer = LayerMask.GetMask("Wall");
    int layer = 1 << 9;
    List<RaycastHit> hits;
    private void Update()
    {
        // ��� 1�� = �̰Ŵ� ��� �ʱ�ȭ �ϴ� �̽������� ���� �����ٰ� �����ϴµ�, �̰� ��� ���������� ������ ���� ���� ����ΰ� ���⵵�ϴ�.
        if (beforeRaycastHits != null)
        {
            foreach (RaycastHit item in beforeRaycastHits)
            {
                Renderer rd = item.transform.GetComponent<Renderer>();
                rd.material.SetFloat("_Alpha", 1f);
            }
            beforeRaycastHits = null;
        }
        dir = player.transform.position - mainCamera.transform.position;
        raycastHits = Physics.RaycastAll(mainCamera.transform.position, dir, 100, layer);
        if (raycastHits.Length > 0)
        {
            beforeRaycastHits = raycastHits;
            //Debug.DrawLine(mainCamera.transform.position, dir, Color.red, 3);
            foreach (RaycastHit item in raycastHits)
            {
                Renderer rd = item.transform.GetComponent<Renderer>();
                rd.material.SetFloat("_Alpha", 0.1f);
            }
        }
        else
        {
            beforeRaycastHits = null;
        }
        

        // ���2�� - �̹���� ���� ��ĺ��� �� �����Ƽ� �̴�� ���ҿ���
        // �迭�� �þ�ٰ� �پ����ٰ� ��� �ݺ���
        /*
        dir = player.transform.position - mainCamera.transform.position;
        raycastHits = Physics.RaycastAll(mainCamera.transform.position, dir, 100, layer);
        if (raycastHits.Length > 0)
        {
            foreach (RaycastHit item in raycastHits)
            {
                Renderer rd = item.transform.GetComponent<Renderer>();
                rd.material.SetFloat("_Alpha", 0.1f);
                if (!hits.Contains(item))
                {
                    hits.Add(item);
                }
            }
        }
        
        if (hits.Count > 0)
        {
            for (int i = 0; i < raycastHits.Length; i++)
            {
                if (hits.Contains())
                {

                }
            }
        }
        */
    }
}
