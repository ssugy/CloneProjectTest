using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class _8_18_GameManager : MonoBehaviour
{
    public Transform mobParent;
    List<_8_18_Monster> mobList;

    private void Awake()
    {
        mobList = new List<_8_18_Monster>();
    }

    void Start()
    {
        Vector3 rayPos = Vector3.zero;
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            rayPos.x = x;
            rayPos.z = z;
            CreateCharacter(rayPos, "Cube");
        }
    }

    /*public _8_18_Monster CreateCharacter(Vector3 _origin, string _name)
    {
        _origin.y += 100;
        RaycastHit hit;
        if (Physics.Raycast(_origin, -Vector3.up, out hit, Mathf.Infinity))
        {
            GameObject rcCha = _8_18_ResourceManager.instance.GetCharacter(_name);
            GameObject obj = GameObject.Instantiate<GameObject>(rcCha, hit.point, Quaternion.identity);
            _8_18_Monster script = obj.AddComponent<_8_18_Monster>();
            mobList.Add(script);    // ��ũ��Ʈ ����
            return script;  // Ȥ�� ���� ��ȯ. �ʿ��ϸ� ����϶�� �ǹ�
        }
        return null;
    }*/

    public _8_18_Monster CreateCharacter(Vector3 _origin, string _name)
    {
        Vector3? terrainPos = GetTerrainPosition(_origin);
        if (terrainPos.HasValue)    // �η��� �� �ִ��� Ȯ���ϴ� ��.
        {
            GameObject rcCha = _8_18_ResourceManager.instance.GetCharacter(_name);
            GameObject obj = GameObject.Instantiate<GameObject>(rcCha, terrainPos.Value, Quaternion.identity);  // �η��� �� �����ö� �̷��� �Ѵ�.
            obj.transform.SetParent(mobParent);
            _8_18_Monster script = obj.AddComponent<_8_18_Monster>();
            mobList.Add(script);    // ��ũ��Ʈ ����
            return script;  // Ȥ�� ���� ��ȯ. �ʿ��ϸ� ����϶�� �ǹ�
        }
        return null;
    }

    // �η��� ó���Ѱ� �λ����. vector3�� ���� ���µ�, ���� �� ����.
    public Vector3? GetTerrainPosition(Vector3 _origin)
    {
        _origin.y += 100;
        RaycastHit hit;
        if (Physics.Raycast(_origin, -Vector3.up, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        return null;
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ����� 1������
            int[] arr = { 1, 100, 20, 30, 56, 23, 2 };
            List<int> list = new List<int>(arr);
            list.Sort();
            arr.Max();
            arr.Min();
        }
    }
}
