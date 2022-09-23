using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color =  new Color(1, 0, 0);
        Color color2 =  new Color(0, 1, 0);
        Debug.Log(color + color2);
    }

    
}
