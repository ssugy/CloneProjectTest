using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_30_Player : MonoBehaviour
{
    public void OnCollisionStayInBound(GameObject obj)
    {
        Debug.Log(obj.name + "�� �浹");
    }

    private void Update()
    {
        List<GameObject> collisionList = _11_30_Character.instatnce.GetCollisionList;
    }
}
