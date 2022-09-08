using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Std_0906 : MonoBehaviour
{
    /**
     * 실습. 자식의 게임 오브젝트에서 특정 게임오브젝트를 검색하는 함수 작성
     * 사용함수
     * transform 멤버함수 GetChild로만 재귀호출로 찾아라라는 요구사항
     */

    private void Start()
    {
        //Debug.Log(transform.Find("Bip001")); //find는 자신의 한단계 객체까지만 가능함
        Debug.Log(FindGameObjectInChild("Bip001 R Thigh", transform));
    }

    // 내가 푼 방법. 마지막에 return에서 가져오는 것이 조금 미흡했지만, 로직구성은 잘 생각함.
    Transform FindGameObjectInChild(string _name, Transform _tr)
    {
        if (_tr.name.Equals(_name))
            return _tr;
        int childNum = 0;
        while (_tr.childCount > childNum)
        {
            Transform childTr = FindGameObjectInChild(_name, _tr.GetChild(childNum));
            childNum++;
            if (childTr != null)
                return childTr;
        }
        return null;
    }

    // 강사님코드
    public Transform FindGameObjectInChild_Teacher(string _name, Transform _tr)
    {
        if (_tr.name == name)
            return _tr;
        for (int i = 0; i < _tr.childCount; i++)
        {
            Transform childTr = FindGameObjectInChild_Teacher(_name, _tr.GetChild(i));
            if (childTr != null)
                return childTr;
        }
        return null;
    }

    // 수업 - mathf.lerp
    // animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp    
    static float t = 0.0f;

    void Update()
    {
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        // .. and increate the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
