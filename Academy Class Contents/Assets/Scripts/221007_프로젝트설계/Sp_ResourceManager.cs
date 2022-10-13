using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_ResourceManager : SingleTon<Sp_ResourceManager>
{
    List<GameObject> rcCharlist;
    const string charFolder = "Character";
    public void LoadCharacter()
    {
        rcCharlist = new List<GameObject>();
        GameObject[] objs = Resources.LoadAll<GameObject>(charFolder);
        foreach (GameObject one in objs)
        {
            rcCharlist.Add(one);
        }
    }
    public GameObject GetRcCharacter(string _name)
    {
        return rcCharlist.Find(o => (o.name.Equals(_name)));
    }
}
