using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 리소스 폴더에서 파일을 가져와서 하이라키 창에 보여주는 것
 * [문제]
 * Character 폴더에 있는 프리팹을 로드하여 리스트에 저장
 * 리스트에서 원하는 게임오브젝트를 검색하여 인스턴스를 생성하는 함수를 제작
 * (참고) 리소스만 저장하고 있는 별도의 클래스를 제작해야 한다.(싱글톤과 같은 클래스 이용)
 * 
 * 유니티 에셋의 자료형을 설명 할 수 있다.
 * 1. 텍스트 기반 파일 : TextAsset
 * 2. 텍스처 : Texture2D
 * 3. 스프라이트 : Sprite
 * 4. 프리팹 : GameObject
 */
public class Std220805_Resources : MonoBehaviour
{
    private void Start()
    {
        // 로드는 메모리에 올려진 것을 의미
        // 화면에 보여지는 것은 아니다.
        GameObject tmp = Resources.Load("Character/Meshtint Free Knight") as GameObject;
        // 씬에 인스턴스 생성
        GameObject obj = GameObject.Instantiate(tmp, new Vector3(3, 3, 3), Quaternion.identity);
        obj.name = "Meshtint Free Knight";

        // Weapon폴더에 존재하는 모든 에셋을 로드
        GameObject[] weapons = Resources.LoadAll<GameObject>("Weapon/");
        // 로드한 게임오브젝트의 인스턴스를 씬에 생성
        foreach (GameObject item in weapons)
        {
            Instantiate(item, new Vector3(1, 1, 1), Quaternion.identity);
            
        }

if (Input.GetKey(KeyCode.UpArrow))
{
// 이동내용 구현
}
    }
}
