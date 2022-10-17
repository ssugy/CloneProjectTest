using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleClass : MonoBehaviour
{
    //방법 1 : 각각 생성하기
    //public NE_Class2 c1;
    //public NE_Class2 c2;
    //public NE_Class2 c3;

    // 방법 2 : 배열로 생성하기
    //public NE_Class2[] c = new NE_Class2[3];   // 0 1 2 => 크기

    // 방법 3 : 리스트로 생성하기
    public List<NE_Class2> ne;


    private void Start()
    {
        // 방법 1 - 초기화
        //Debug.Log(c1.num1); //10
        //Debug.Log(c2.num1); //20

        // 방법 2 - 초기화
        //c[0].num1 = 10;
        //c[1].num1 = 10;
        //c[2].num1 = 10;

        //Debug.Log(c[0].num1);    // 10
        //Debug.Log(c[1].num1);    // 10
        //Debug.Log(c[2].num1);    // 10

        // 방법 3 - 리스트
        // 1) 리스트의 사용은 최초에 메모리 할당을 해야됩니다.
        // 2) 리스트에 ADD합니다.
        // 3) 리스트변수[인덱스]를 이용해서 접근이 가능합니다.
        
        // 예를들어서 int형 변수 5개를 1 2 3 4 5이렇게 값이 들어가있는 리스트를 선언하겠다.
        //List<int> c = new List<int>(); //  계속 넣을 수 있다.(이 리스트에) => 이거 메모리 할당하면 터지겠네요? -> 아이템을 추가 할 때 마다 메모리를 추가로 할당하는 방식.
        //c.Add(1);   //인덱스가 0일 때
        //c.Add(2);
        //c.Add(3);
        //c.Add(4);   // 인덱스가 3일 때
        //c.Add(5);
        //Debug.Log(c[3]); //4 -맞음

        //NE_Class2 ne2 = new NE_Class2();
        //ne.Add(ne2);    // 클래스 추가

        ne[0].ShowNum(10);
        ne[1].ShowNum(10);
        ne[2].ShowNum(10);
        
    }

    public int[] test;  // 인스펙터 창에서 크기를 정한다 = 메모리를 알아서 할당해준다. 그래서 new가 필요없음

    private void Update()
    {
        // 버튼 눌럿을 때 10 20 30
        if (Input.GetMouseButtonDown(0))
        {
            //c2.num1 = 30;
            //Debug.Log(c1.num1); //10

            //c[0].num1 = 10;
            //c[1].num1 = 20;
            //c[2].num1 = 30;  

            ne[0].num1 = 10;
            ne[1].num1 = 20;
            ne[2].num1 = 30;
        }
    }
}
