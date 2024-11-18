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
    public float dano;
    [SerializeField]private float multiplicador =1;
    public GameObject danoText;
    public bool colidiu = false;
    public GameObject explosao;



    void Start()
    {
        if(nome == "MegaBala")
        {
            speed = 35;
        }
        myRb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        minhaPosicao = transform.position;
        if (minhaPosicao.y > dano)
        {
            //Debug.Log(dano);
            dano = (int)minhaPosicao.y * multiplicador;
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
        if (collision.CompareTag("Castelo"))
        {
            var danoC = danoText.GetComponent<FeedbackDanoController>();
            int danoR =(int) dano;
            //collision.gameObject.GetComponent<PlayerControler>().ReceberDano(danoR);
            danoC.texto.text = danoR.ToString();
            Instantiate(danoText, minhaPosicao + new Vector3(0, 2, 0), Quaternion.identity);
        }
        
        Destroy(gameObject);
        
        
        colidiu = true;
        
    }
}