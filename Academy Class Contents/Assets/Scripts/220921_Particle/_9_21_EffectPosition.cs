using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_21_EffectPosition : MonoBehaviour
{
    GameObject rcRhandEffect;
    //string effectDummyPath = "TrollGiant/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/HR/RHandEffect";
    string effectDummyPath = "RHandEffect";
    Transform rhandDummy;
    public TrailRenderer swordEffect;
    // Start is called before the first frame update
    void Start()
    {
        swordEffect.enabled = false;
        rcRhandEffect = Resources.Load<GameObject>("Effect/FireEffect");
        // GameObject.Find함수의 단점
        // 활성화된 게임오브젝트만 검색
        // 비활성화된 게임오브젝트일경우는 Transform의 맴버함수를 사용하여 검색
        //rhandDummy = GameObject.Find(effectDummyPath).transform;
        rhandDummy = FindChildTransfom(effectDummyPath, transform);
    }
    // 
    public Transform FindChildTransfom(string _nodeName, Transform _origin)
    {
        if (_origin.name == _nodeName)
            return _origin;
        for (int i = 0; i < _origin.childCount; i++ )
        {
            Transform findTr = FindChildTransfom(_nodeName, _origin.GetChild(i));
            if (findTr != null)
                return findTr;
        }
        return null;
    }
    public void SwordEffectOn()
    {
        swordEffect.enabled = true;
    }
    public void SwordEffectOff()
    {
        swordEffect.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject rhandEffect = Instantiate<GameObject>(rcRhandEffect, rhandDummy.position, Quaternion.identity, rhandDummy);
        }
    }
}
