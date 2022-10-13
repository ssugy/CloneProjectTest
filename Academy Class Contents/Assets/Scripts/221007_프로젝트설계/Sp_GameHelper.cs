using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���길 �ϴ� �뵵 - ��ƿ��Ƽ Ŭ������ ����
// �����ϰ� �ϳ��� �����ϸ�Ǿ ����ƽ Ŭ������ ����
public static class Sp_GameHelper
{
    /// <summary>
    /// �ϴÿ��� �ٴ����� ���̾ ������, �÷��̾ ������ ������ ��� �浹 ����
    /// </summary>
    /// <param name="_origin">���̸� �˱����� ��������ġ</param>
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
