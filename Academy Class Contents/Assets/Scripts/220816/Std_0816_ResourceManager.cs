using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_0816_ResourceManager : MonoBehaviour
{
    public static Std_0816_ResourceManager instance;
    List<GameObject> rcCharList;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        rcCharList = new List<GameObject>();
        // 캐릭터 폴더에 있는 프리팹을 로드
        GameObject[] tmpChars = Resources.LoadAll<GameObject>("Character/");
        foreach (GameObject one in tmpChars)
        {
            rcCharList.Add(one);
        }
    }
    public GameObject GetCharResource(string _name)
    {
        foreach(GameObject one in rcCharList)
        {
            if(one.name.Equals(_name))
            {
                return one;
            }
        }
        return null;
    }    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
