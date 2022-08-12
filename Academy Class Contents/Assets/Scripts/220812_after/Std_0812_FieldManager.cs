using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_0812_FieldManager : MonoBehaviour
{
    //public Std_0812_ResourcesManager resourcesManager;  // 싱글톤으로 변경해서 이제 이렇게 사용안함
    private Std_0812_Player player;
    private List<Std_0812_Monster> mobList;

    public void CreatePlayerCharacter(string _name)
    {
        GameObject tmpePlayerChar = Std_0812_ResourcesManager.instance.GetCharResource(_name);
        if (tmpePlayerChar != null)
        {
            player = Instantiate(tmpePlayerChar).AddComponent<Std_0812_Player>();
        }
    }

    public void CreateMonster(string _name)
    {
        GameObject tmpMonster = Std_0812_ResourcesManager.instance.GetMonsterResource(_name);
        if (tmpMonster != null)
        {
            //강사님 스타일
            GameObject monsterObject = Instantiate(tmpMonster);
            Std_0812_Monster monster = monsterObject.AddComponent<Std_0812_Monster>();
            mobList.Add(monster);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CreatePlayerCharacter("Meshtint Free Knight");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreatePlayerCharacter("");
        }
    }
}
