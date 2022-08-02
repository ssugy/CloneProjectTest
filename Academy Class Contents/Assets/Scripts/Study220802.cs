using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 클릭하면 몬스터 삭제되게 만들기
public class Study220802 : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hitInfo;
    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        // 생성된 오브젝트를 빈게임오브젝트의 자식으로 지정
        GameObject monsterParent = new GameObject("Mob");
        monsterParent.transform.position = Vector3.zero;    // 이거 사실 필요없는 코드임. 0,0,0으로 초기화가 된다.
        
        // 씬 시작 시 오브젝트 생성
        for (int i = 1; i <= 10; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.tag = "Monster";
            go.layer = 7;   // 지정하는 레이어는 0부터 31사이 값으로 넣어야 된다. 레이어 마스크가 아님.
            go.name = "Monster_" + i;
            go.transform.position = new Vector3(Random.Range(0, 10)
                                                , Random.Range(0, 10)
                                                , Random.Range(0, 10));
            list.Add(go);
            
            // 자식오브젝트.tranform.setParent(부모오브젝트); 이렇게 쓴다.
            go.transform.SetParent(monsterParent.transform, false);
        }

        // 3번 오브젝트를 비활성화 하기
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

    // 게임오브젝트 검색
    public GameObject searchObj(string _name)
    {
        // 방법 4개 - 동일한 이름이면 하나만 반납한다.
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
