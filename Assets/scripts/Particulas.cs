using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    private Renderer minhaPariticula;
    private float xOffset = 0;
    private Vector2 TextureOffset;
    // Start is called before the first frame update
    void Start()
    {
        minhaPariticula = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.01f;
        xOffset -= Time.deltaTime*speed;
        TextureOffset.x = xOffset;
        minhaPariticula.material.mainTextureOffset = TextureOffset;
    }
}
