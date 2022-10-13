using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_GameManager : MonoBehaviour
{
    public static Sp_GameManager instance;  // �̷��� �ٷ� ������ ���� �ȵ�.
    public Transform playerParent;
    public Transform monsterParent;
    private void Awake()
    {
        instance = this;
        Sp_InstanceManager.instance.Initialize();
        Sp_InstanceManager.instance.CreatePlayer("TrollGiant", playerParent);
        Sp_InstanceManager.instance.CreateMonster("TrollGiant", monsterParent);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
