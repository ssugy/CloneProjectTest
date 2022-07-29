using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_7_21 : MonoBehaviour
{
    List<int> list;

    void Start()
    {
        list = new List<int>();
        list.Add(100);
        list.Add(200);
        list.Add(300);
        list.Add(400);
        list.Add(500);
        // list.Count는 저장된 원소의 개수를 의미
        Debug.Log("리스트에 저장된 원소의 개수 = " + list.Count);
        // 배열처럼 사용할 수 있다.////////////////////////////////////////////////////////////////////////
        Debug.Log(list[0]);     // 리스트 첫번재 노드의 값 출력
        Debug.Log(list[1]);
        Debug.Log(list[2]);
        Debug.Log(list[3]);
        Debug.Log(list[4]);
        //Debug.Log(list[5]);     // 리스트에 저장되어 있지 않은 데이터 이므로 오류발생
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 데이터 검색 
        // 데이터가 300인 노드를 찾아서 값을리턴받아서 저장
        // 아래의 식을 람다식 이라고 한다.
        int data = list.Find(o => (o == 300));
        // 데이터 정렬
        // 오름차순 정렬
        list.Sort((x, y) => x.CompareTo(y));
        // 내림차순 정렬
        list.Sort((x, y) => y.CompareTo(x));
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //리스트 원소 삽입
        list.Insert(0, 1000);
        Debug.Log(list[0]);
    }

    void Update()
    {
        
    }
}

