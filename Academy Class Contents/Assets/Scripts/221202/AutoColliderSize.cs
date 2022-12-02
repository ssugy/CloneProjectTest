using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using static UnityEditor.Progress;

/// <summary>
/// 게임오브젝트의 박스 콜라이더를 자동화 시켜주는 프로그램.
/// (게임오브젝트의 크기를 계산하여 박스 콜라이더를 생성해주는 프로그램)
/// </summary>
public class AutoColliderSize : MonoBehaviour
{
    public GameObject go;

    void Start()
    {
        CreatefitCollider(go);
    }

    
    private void CreatefitCollider(GameObject obj)
    {
        Bounds bd = new Bounds();   // 모두 합쳐진 크기의 Bound저장용 변수
        Renderer[] sample = obj.GetComponentsInChildren<Renderer>();

        // 0. 오브젝트를 원점 기준으로 처리한다.
        Vector3 oldPos = obj.transform.position;
        obj.transform.position = Vector3.zero;

        // 1. 자식컴포넌트들 중에서 Renderer를 상속받은 객체가 있다면, 해당 객체에서의 Bound크기를 모두 합친다.
        for (int i = 0; i < sample.Length; i++)
        {
            bd.Encapsulate(sample[i].bounds);   // Bounds를 모두 합쳐주는 함수 Encapsulate
        }

        // 2. 모두 합쳐진 Bound크기의 Collider를 생성.
        BoxCollider boxCol = obj.AddComponent<BoxCollider>();
        boxCol.size = bd.size;
        boxCol.center = bd.center;
        obj.transform.position = oldPos;

        // 3. 콜라이더가 추가된 객체를 프리팹으로 만들어서 저장한다.
        string url = Application.dataPath + "/Resources/NewPrefabs/" + name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(obj, url);
    }

    [MenuItem("/Prefabs/GenerateColliderPrefabs")]
    public static void GenerateColliderPrefabs()
    {
        Debug.Log("실행");
        string path = "OldPrefabs";
        List<GameObject> objs = Resources.LoadAll<GameObject>(path).ToList<GameObject>();
        //objs.RemoveAll((a) =>
        //    !a.name.Contains(".prefab")   // 이거안됨. 리소스로드 게임오브젝트는 확장자를 포함한 이름이 아님.
        //);  // 프리팹이라는 이름이 없는 오브젝트는 리스트에서 모두 삭제 - 이게 어차피 게임오브젝트라서 자동으로 걸러짐.

        for (int i = 0; i < objs.Count; i++)
        {
            GameObject tmpGo = GameObject.Instantiate(objs[i]);

            Bounds bd = new Bounds();   // 모두 합쳐진 크기의 Bound저장용 변수
            Renderer[] sample = tmpGo.GetComponentsInChildren<Renderer>();

            // 0. 오브젝트를 원점 기준으로 처리한다.
            Vector3 oldPos = tmpGo.transform.position;
            tmpGo.transform.position = Vector3.zero;

            // 1. 자식컴포넌트들 중에서 Renderer를 상속받은 객체가 있다면, 해당 객체에서의 Bound크기를 모두 합친다.
            for (int j = 0; j < sample.Length; j++)
            {
                bd.Encapsulate(sample[j].bounds);   // Bounds를 모두 합쳐주는 함수 Encapsulate
            }

            // 2. 모두 합쳐진 Bound크기의 Collider를 생성.
            BoxCollider boxCol = tmpGo.AddComponent<BoxCollider>();
            boxCol.size = bd.size;
            boxCol.center = bd.center;
            tmpGo.transform.position = oldPos;

            // 3. 콜라이더가 추가된 객체를 프리팹으로 만들어서 저장한다.
            string url = Application.dataPath + "/Resources/NewPrefabs/" +tmpGo.name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(tmpGo, url);
        }
    }
}
