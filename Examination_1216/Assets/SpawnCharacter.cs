using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    bool isReadyShow;   // 한번만 출력하기 위해 만들어둔 변수
    Character player;
    private void Awake()
    {
        isReadyShow = true;
    }

    void Start()
    {
        player = new Character();
        Debug.Log("인스턴스가 생성되었습니다.");
        player.Attack(5);
        player.Defence(5);
        player.LevelUP(10);
    }

    void Update()
    {
        if (isReadyShow && Time.time >= 3)
        {
            isReadyShow = false;
            Debug.Log("이름은  = " + player.NAME + "입니다.");
            Debug.Log("나이는  = " + player.AGE + "입니다.");
            Debug.Log("성별은  = " + player.SEX + "입니다.");
            Debug.Log("레벨은  = " + player.Level + "입니다.");
            Debug.Log("체력은  = " + player.HP + "입니다.");
        }
    }
}
