using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 45;
    private Rigidbody2D myRb;
    public Vector3 minhaPosicao;
    public int dano;
    public bool colidiu = false;
    public GameObject explosao;



    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        minhaPosicao = transform.position;
        if (minhaPosicao.y > dano)
        {
            //Debug.Log(dano);
            dano = (int)minhaPosicao.y;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosao, minhaPosicao, Quaternion.identity);
        Destroy(gameObject);
        colidiu = true;
        
    }
}