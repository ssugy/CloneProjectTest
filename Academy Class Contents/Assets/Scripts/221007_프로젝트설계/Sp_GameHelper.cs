using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연산만 하는 용도 - 유틸리티 클래스를 말함
// 유일하게 하나만 존재하면되어서 스태틱 클래스로 제작
public static class Sp_GameHelper
{
    /// <summary>
    /// 하늘에서 바닥으로 레이어를 보내고, 플레이어를 제외한 나머지 모두 충돌 가능
    /// </summary>
    /// <param name="_origin">높이를 알기위한 목적지위치</param>
    /// <returns></returns>
    public static Vector3 GetHeightMapPos(Vector3 _origin)
    {
        Vector3 origin = _origin;
        origin.y += 200f;
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;
        if (Physics.Raycast(origin, Vector3.down, out hitInfo, Mathf.Infinity))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }
}
