using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ResourceManager에 저장된 프리팹의 인스턴스를 검색하여 원하는 인스턴스를 생성
 */
public class Std_0816_GameManager : MonoBehaviour
{
    Std_0816_Player player;
    private void Awake()
    {
    }
    void Start()
    {
        CreateCharacterInstance("Cube");
    }
    public void CreateCharacterInstance(string _name)
    {
        GameObject tmp = Std_0816_ResourceManager.instance.GetCharResource(_name);
        if(tmp != null)
        {
            GameObject playerObject = GameObject.Instantiate<GameObject>(tmp);
            player = playerObject.AddComponent<Std_0816_Player>();
            //_8_16_CustomCamera cam = Camera.main.GetComponent<_8_16_CustomCamera>();
            Std_0816_CustomCamera.instance.PLAYER = player;
            Std_0816_CustomCamera.instance.PLAYEROLDPOS = player.transform.position;
        }
    }
    void Update()
    {
        
    }
}
