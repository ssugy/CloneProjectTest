using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * �̱������� ����
 */
public class Std_0812_ResourcesManager : MonoBehaviour
{
    static private Std_0812_ResourcesManager _unique;
    static public Std_0812_ResourcesManager instance
    {
        get { return _unique; }
    }

    List<GameObject> rcPlayerCharlist = new List<GameObject>();
    List<GameObject> rcMoblist = new List<GameObject>();
    List<GameObject> rcNpclist = new List<GameObject>();

    private void Awake()
    {
        _unique = this; // �̱��� ����
        rcPlayerCharlist.AddRange(Resources.LoadAll<GameObject>("Character/"));
        rcMoblist.AddRange(Resources.LoadAll<GameObject>("Monster/"));
        rcNpclist.AddRange(Resources.LoadAll<GameObject>("Npc/"));
    }

    public GameObject GetCharResource(string _name)
    {
        return rcPlayerCharlist.Find(x => x.name.Equals(_name));
    }

    public GameObject GetMonsterResource(string _name)
    {
        return rcMoblist.Find(x => x.name.Equals(_name));
    }

    public GameObject GetNpcResource(string _name)
    {
        return rcNpclist.Find(x => x.name.Equals(_name));
    }
}
