using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class _10_13_Slot : MonoBehaviour
{
    public Image uiIcon;
    [SerializeField] private RectTransform rcTransform;
    Rect rc;
    public Rect RC
    {
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            return rc;
        }
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        rcTransform = GetComponent<RectTransform>();

        // x, y�� �»������ �ϴ� Rect ����ü 
        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
        rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
        rc.xMin = rc.x;
        rc.yMin = rc.y;
        rc.xMax = rc.x + rcTransform.rect.width;
        rc.yMax = rc.y + rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
    }
    // �Ű������� ���޵� _pos�� rc�� ���ԵǴ��� �˻�
    public bool IsInRect(Vector2 _pos)
    {
        if (_pos.x >= RC.x && 
            _pos.x <= RC.x + RC.width &&
            _pos.y >= RC.y - RC.height && 
            _pos.y <= RC.y)
            return true;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
