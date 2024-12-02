using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private string conteudo;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float numeroSort = Random.Range(0f, 1f);
        if (numeroSort <= 0.33f)
        {
            conteudo = "mega";

        }
        else if(numeroSort <= 0.66f)
        {

            conteudo = "gost";
        }
        else
        {
            conteudo = "mina";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        if (objeto.CompareTag("P1")|| objeto.CompareTag("P2"))
        {
            Destroy(gameObject);
            //Debug.Log("Entrou");
        }
        if (objeto.CompareTag("Drabor"))
        {
            
            transform.Translate(transform.up*35*Time.fixedDeltaTime);
        }
    }
    public string getConteudo()
    {
        return conteudo;
    }
}
