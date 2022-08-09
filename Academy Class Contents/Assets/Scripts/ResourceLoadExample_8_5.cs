using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoadExample_8_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 로드는 메모리에 올려진것을 의미
        // 화면에 보여지는 것은 아니다.
        GameObject tmp = Resources.Load("Character/Meshtint Free Knight") as GameObject;
        // 씬에 인스턴스생성
        GameObject obj = GameObject.Instantiate(tmp, new Vector3(3,3,3), Quaternion.identity);
        obj.name = "Meshtint Free Knight";
        //
        // Weapon폴더에 존재하는 모든 애샛을 로드
        GameObject [] weapons = Resources.LoadAll<GameObject>("Weapon/");
        // 로드한 게임오브젝트의 인스턴스를 씬에 생성
        foreach(GameObject one in weapons)
        {
            GameObject weapon = GameObject.Instantiate<GameObject>(one);
            weapon.name = one.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
