using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_GPUInstancing : MonoBehaviour
{
    List<GameObject> objects;

    void Start()
    {
        objects = new List<GameObject>();
        GameObject tmp = Resources.Load<GameObject>("Sphere");
        for (int i = 0; i < 10; i++)
        {
            objects.Add(Instantiate<GameObject>(tmp));
        }

        MaterialPropertyBlock props = new MaterialPropertyBlock();
        MeshRenderer renderer;
        foreach (GameObject item in objects)
        {
            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);
            props.SetColor("_Color", new Color(r, g, b));
            renderer = item.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
        }
    }

    
}
