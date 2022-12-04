using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_30_Character : MonoBehaviour
{
    List<BoxCollider> colliderList;
    BoxCollider player;
    public static _11_30_Character instatnce;

    public List<GameObject> GetCollisionList
    {
        get
        {
            List<GameObject> collisionList = null;
            for (int i = 0; i < colliderList.Count; i++)
            {
                if (player.bounds.Intersects(colliderList[i].bounds))
                {
                    if (collisionList == null)
                    {
                        collisionList = new List<GameObject>();
                    }
                    collisionList.Add(colliderList[i].gameObject);
                }
            }
            return collisionList;
        }
    }

    void Start()
    {
        instatnce = this;
        colliderList = new List<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < mobs.Length; i++)
        {
            colliderList.Add(mobs[i].GetComponent<BoxCollider>());
        }
    }

    void Update()
    {
        for (int i = 0; i < colliderList.Count; i++)
        {
            if (player.bounds.Intersects(colliderList[i].bounds))
            {
                // 이거 함수이름 제대로 써야한다.
                player.gameObject.SendMessage("OnCollisionStayInBound", colliderList[i].gameObject);
            }
        }
    }
}
