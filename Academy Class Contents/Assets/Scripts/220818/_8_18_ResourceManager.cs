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

    // 리소스 로드
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

    // 리스트에 있는 아이템 꺼내기
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
