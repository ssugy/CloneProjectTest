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

    // 에디터에서 값 바뀔때마다 호출됨
    //private void OnValidate()
    //{
    //    // material쓰면 메모리 누수된다고 말하고 sharedMaterial쓰라고 함.
    //    renderer.sharedMaterial.SetFloat("_Alpha", alpha);
    //}

    // 플레이어 이동하면 화면 반투명 해지게 하기.
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
        // 방법 1번 = 이거는 사실 초기화 하는 이슈때문에 별로 안좋다고 생각하는데, 이게 사실 실질적으로 연산이 제일 적은 방법인것 같기도하다.
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
        

        // 방법2번 - 이방식이 위에 방식보다 더 안좋아서 이대로 안할예정
        // 배열이 늘어났다가 줄어들었다가 계속 반복됨
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
