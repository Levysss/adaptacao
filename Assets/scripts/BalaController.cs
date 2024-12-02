using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    // Start is called before the first frame update
    public string nome;
    private float speed = 45;
    private Rigidbody2D myRb;
    private Vector3 minhaPosicao;
    public int dano;
    [SerializeField]private int multiplicador =1;
    public GameObject danoText;
    public bool colidiu = false;
    private bool gost = false;
    public GameObject explosao;



    void Start()
    {
        if(nome == "MegaBala")
        {
            speed = 55;
        }
        if(nome == "Fantasma")
        {
            speed = 55;
            gost = true;
        }
        if (nome == "mina")
        {
            speed = 45;
            gost = true;
        }
        myRb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        minhaPosicao = transform.position;
        if (minhaPosicao.y > dano)
        {
            int danoR = (int)minhaPosicao.y;
            dano = danoR * multiplicador;
            //Debug.Log(dano);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (colidiu == false||nome == "Fantasma")
        {
            transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Castelo"))
        {
            var danoC = danoText.GetComponent<FeedbackDanoController>();
            
            //collision.gameObject.GetComponent<PlayerControler>().ReceberDano(danoR);
            danoC.texto.text = dano.ToString();
            Instantiate(danoText, minhaPosicao + new Vector3(0, 2, 0), Quaternion.identity);
        }
        bool mina=false;
        if (nome == "mina")
        {
            mina = true;
            if (collision.CompareTag("Castelo")|| collision.CompareTag("rio"))
            {
                Instantiate(explosao, minhaPosicao, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                
                transform.position = minhaPosicao;
                myRb.bodyType = RigidbodyType2D.Static;
                colidiu = true;
            }
        }

        
        if (!gost&&!mina)
        {
            Instantiate(explosao, minhaPosicao, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            if (collision.CompareTag("Castelo")||collision.CompareTag("rio"))
            {
                Instantiate(explosao, minhaPosicao, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        
        
        colidiu = true;
        
    }
}