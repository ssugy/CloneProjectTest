using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_30_Character : MonoBehaviour
{
    List<BoxCollider> colliderList;
    BoxCollider player;
    void Start()
    {
        colliderList = new List<BoxCollider>();
        player = GetComponent<BoxCollider>();
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
                player.gameObject.SendMessage("OnCollisionStay in Bound");
            }
        }
    }
}
