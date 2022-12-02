using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * 게임오브젝트에 박스 콜라이더를 자동화하는 코드
 * 프리팹 추가: https://docs.unity3d.com/ScriptReference/PrefabUtility.SaveAsPrefabAsset.html
 */
public class ColliderGenerator_teacher : MonoBehaviour
{
    private void Awake()
    {
        SkinnedMeshRenderer smr =  FindChildComponent(transform);
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.center = smr.bounds.center - transform.position;
        collider.size = smr.bounds.size;

        // 프리팹 제작
        string localPath = Application.dataPath + "/Resources/" + transform.name + ".prefab";
        bool prefabSuccess;
        PrefabUtility.SaveAsPrefabAsset(gameObject, localPath, out prefabSuccess);
        Debug.Log("프리팹 저장 성공 유무 : " + prefabSuccess);
    }

    private SkinnedMeshRenderer FindChildComponent(Transform _tr)
    {
        SkinnedMeshRenderer smr = _tr.GetComponent<SkinnedMeshRenderer>();
        if (smr != null)
            return smr;

        for (int i = 0; i < _tr.childCount; i++)
        {
            Transform tr = _tr.GetChild(i);
            smr = FindChildComponent(tr);
            if (smr != null)
                return smr;
        }
        return null;
    }

    [MenuItem("Collider/ColliderGenerator")]
    public static void CtreateGenerator()
    {
        GameObject[] objs = Resources.LoadAll<GameObject>("Character");
        for (int i = 0; i < objs.Length; i++)
        {
            SkinnedMeshRenderer smr = objs[i].GetComponentInChildren<SkinnedMeshRenderer>();
            BoxCollider collider = objs[i].AddComponent<BoxCollider>();
            collider.center = smr.bounds.center - objs[i].transform.position;
            collider.size = smr.bounds.size;
            PrefabUtility.SavePrefabAsset(objs[i]); // 프리팹에 저장
        }
    }
}
