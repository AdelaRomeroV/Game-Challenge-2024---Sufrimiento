using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textura : MonoBehaviour
{
    private Material material;
    void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void FixedUpdate()
    {
        material.mainTextureOffset += Vector2.right * Time.fixedDeltaTime;
    }
}
