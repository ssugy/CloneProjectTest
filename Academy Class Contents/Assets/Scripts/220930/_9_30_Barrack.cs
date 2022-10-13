using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_Barrack : MonoBehaviour
{
    public float elapsed;
    public int barrackIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 4초마다 한번씩
        elapsed += Time.deltaTime;
        if(elapsed >= 4f)
        {
            elapsed -= 4f;
            GameObject createdMob = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            _9_30_Monster monsterComponent = createdMob.AddComponent<_9_30_Monster>();
            monsterComponent.transform.position = transform.position;
            monsterComponent.END = new Vector3(transform.position.x, transform.position.y, 4f);
            monsterComponent.barrackIndex = barrackIndex;
            monsterComponent.moveSpeed = 1.5f;
            monsterComponent.tag = "Monster";
        }
    }
}
