using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_15_PropertyValue : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.SetFloat("_Alpha", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
