using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_0816_CustomCamera : MonoBehaviour
{
    public static Std_0816_CustomCamera instance;
    Std_0816_Player player;
    Vector3 oldPos;
    public Std_0816_Player PLAYER
    {
        get { return player;  }
        set { player = value; }
    }
    public Vector3 PLAYEROLDPOS
    {
        get { return oldPos; }
        set 
        {
            oldPos = value;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
    }
    void LateUpdate()
    {
        Vector3 delta = player.transform.position - oldPos;
        transform.position = transform.position + delta;
        oldPos = player.transform.position;
    }
}
