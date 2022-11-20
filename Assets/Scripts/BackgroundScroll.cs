using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public Renderer meshRenderer;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moving the background
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
