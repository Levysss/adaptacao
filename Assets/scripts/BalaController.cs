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
            speed = 35;
        }
        if(nome == "Fantasma")
        {
            speed = 55;
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
            Debug.Log(dano);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
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


        
        if (!gost)
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