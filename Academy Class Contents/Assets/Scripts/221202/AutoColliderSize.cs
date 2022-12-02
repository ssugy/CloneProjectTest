using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using static UnityEditor.Progress;

/// <summary>
/// ���ӿ�����Ʈ�� �ڽ� �ݶ��̴��� �ڵ�ȭ �����ִ� ���α׷�.
/// (���ӿ�����Ʈ�� ũ�⸦ ����Ͽ� �ڽ� �ݶ��̴��� �������ִ� ���α׷�)
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
        Bounds bd = new Bounds();   // ��� ������ ũ���� Bound����� ����
        Renderer[] sample = obj.GetComponentsInChildren<Renderer>();

        // 0. ������Ʈ�� ���� �������� ó���Ѵ�.
        Vector3 oldPos = obj.transform.position;
        obj.transform.position = Vector3.zero;

        // 1. �ڽ�������Ʈ�� �߿��� Renderer�� ��ӹ��� ��ü�� �ִٸ�, �ش� ��ü������ Boundũ�⸦ ��� ��ģ��.
        for (int i = 0; i < sample.Length; i++)
        {
            bd.Encapsulate(sample[i].bounds);   // Bounds�� ��� �����ִ� �Լ� Encapsulate
        }

        // 2. ��� ������ Boundũ���� Collider�� ����.
        BoxCollider boxCol = obj.AddComponent<BoxCollider>();
        boxCol.size = bd.size;
        boxCol.center = bd.center;
        obj.transform.position = oldPos;

        // 3. �ݶ��̴��� �߰��� ��ü�� ���������� ���� �����Ѵ�.
        string url = Application.dataPath + "/Resources/NewPrefabs/" + name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(obj, url);
    }

    [MenuItem("/Prefabs/GenerateColliderPrefabs")]
    public static void GenerateColliderPrefabs()
    {
        Debug.Log("����");
        string path = "OldPrefabs";
        List<GameObject> objs = Resources.LoadAll<GameObject>(path).ToList<GameObject>();
        //objs.RemoveAll((a) =>
        //    !a.name.Contains(".prefab")   // �̰žȵ�. ���ҽ��ε� ���ӿ�����Ʈ�� Ȯ���ڸ� ������ �̸��� �ƴ�.
        //);  // �������̶�� �̸��� ���� ������Ʈ�� ����Ʈ���� ��� ���� - �̰� ������ ���ӿ�����Ʈ�� �ڵ����� �ɷ���.

        for (int i = 0; i < objs.Count; i++)
        {
            GameObject tmpGo = GameObject.Instantiate(objs[i]);

            Bounds bd = new Bounds();   // ��� ������ ũ���� Bound����� ����
            Renderer[] sample = tmpGo.GetComponentsInChildren<Renderer>();

            // 0. ������Ʈ�� ���� �������� ó���Ѵ�.
            Vector3 oldPos = tmpGo.transform.position;
            tmpGo.transform.position = Vector3.zero;

            // 1. �ڽ�������Ʈ�� �߿��� Renderer�� ��ӹ��� ��ü�� �ִٸ�, �ش� ��ü������ Boundũ�⸦ ��� ��ģ��.
            for (int j = 0; j < sample.Length; j++)
            {
                bd.Encapsulate(sample[j].bounds);   // Bounds�� ��� �����ִ� �Լ� Encapsulate
            }

            // 2. ��� ������ Boundũ���� Collider�� ����.
            BoxCollider boxCol = tmpGo.AddComponent<BoxCollider>();
            boxCol.size = bd.size;
            boxCol.center = bd.center;
            tmpGo.transform.position = oldPos;

            // 3. �ݶ��̴��� �߰��� ��ü�� ���������� ���� �����Ѵ�.
            string url = Application.dataPath + "/Resources/NewPrefabs/" +tmpGo.name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(tmpGo, url);
        }
    }
}
