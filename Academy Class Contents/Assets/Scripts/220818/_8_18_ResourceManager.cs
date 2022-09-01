using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _8_18_ResourceManager : MonoBehaviour
{
    public static _8_18_ResourceManager instance;
    private List<GameObject> rcChaList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        CharacterLoad();
    }

    // ���ҽ� �ε�
    public void CharacterLoad()
    {
        if (rcChaList == null)
            rcChaList = new List<GameObject>();

        GameObject[] rcChar = Resources.LoadAll<GameObject>("Character/");
        foreach (GameObject item in rcChar)
        {
            rcChaList.Add(item);
        }
    }

    // ����Ʈ�� �ִ� ������ ������
    public GameObject GetCharacter(string _name)
    {
        foreach (GameObject item in rcChaList)
        {
            if (item.name.Equals(_name))
            {
                return item;
            }
        }
        return null;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
