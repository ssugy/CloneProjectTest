using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 Ŭ���ϸ� ���� �����ǰ� �����
public class Study220802 : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hitInfo;
    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        // ������ ������Ʈ�� ����ӿ�����Ʈ�� �ڽ����� ����
        GameObject monsterParent = new GameObject("Mob");
        monsterParent.transform.position = Vector3.zero;    // �̰� ��� �ʿ���� �ڵ���. 0,0,0���� �ʱ�ȭ�� �ȴ�.
        
        // �� ���� �� ������Ʈ ����
        for (int i = 1; i <= 10; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.tag = "Monster";
            go.layer = 7;   // �����ϴ� ���̾�� 0���� 31���� ������ �־�� �ȴ�. ���̾� ����ũ�� �ƴ�.
            go.name = "Monster_" + i;
            go.transform.position = new Vector3(Random.Range(0, 10)
                                                , Random.Range(0, 10)
                                                , Random.Range(0, 10));
            list.Add(go);
            
            // �ڽĿ�����Ʈ.tranform.setParent(�θ������Ʈ); �̷��� ����.
            go.transform.SetParent(monsterParent.transform, false);
        }

        // 3�� ������Ʈ�� ��Ȱ��ȭ �ϱ�
        searchObj("Monster_3").SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hitInfo, int.MaxValue, 1<<7))
            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.CompareTag("Monster"))
            { 
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }

    // ���ӿ�����Ʈ �˻�
    public GameObject searchObj(string _name)
    {
        // ��� 4�� - ������ �̸��̸� �ϳ��� �ݳ��Ѵ�.
        //GameObject go = list.Find((a) => {return a.name.Equals(_name); });
        //GameObject go = list.Find((a) =>  a.name.Equals(_name));
        //GameObject go = list.Find((a) => (a.name.Equals(_name)));
        //return go;

        foreach (GameObject item in list)
        {
            if (item.name.Equals(_name))
            {
                return item;
            }
        }
        return null;
    }
}
