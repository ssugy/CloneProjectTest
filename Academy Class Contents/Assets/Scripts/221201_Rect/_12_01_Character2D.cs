using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _12_01_Character2D : MonoBehaviour
{
    public _12_01_Character2D other;
    Rect rect;
    public Rect RC { get { return rect; }  }
    private void Start()
    {
        rect.x = transform.position.x;
        rect.y = transform.position.y;
        rect.width = 2.56f;
        rect.height = 2.56f;
    }

    private void Update()
    {
        rect.x = transform.position.x;
        rect.y = transform.position.y;
        if (rect.Overlaps(other.RC))
        {
            Debug.Log(other.gameObject.name + "°ú Ãæµ¹");
        }
    }
}
