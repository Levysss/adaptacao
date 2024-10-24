using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public int vida = 20;
    private Rigidbody2D rb;

    public GameObject roda1;
    public GameObject roda2;
    public GameObject canhao;
    public GameObject bocaCanhao;

    public bool jogando;

    public GameObject minhaBala;
    public GameObject balaAtiva;
    public GameObject mira;
    public Vector2 direcao;
    


    public bool jogou;
    
    float deslocamento = 10;
    float speed = 100;




    Vector2 movimento;
    public void setDeslocamento(InputAction.CallbackContext valui) 
    {
        movimento = valui.ReadValue<Vector2>();
         
    }
    public void setAtirar()
    {
        
        if (jogando && !jogou)
        {
            
            balaAtiva = Instantiate(minhaBala, bocaCanhao.transform.position, canhao.transform.rotation);  
        }
        
    }
    public BalaController GetBala()
    {
        if (balaAtiva != null)
        {
            return balaAtiva.GetComponent<BalaController>();
        }
        return null;
    }


    private void FixedUpdate()
    {
        if (jogando)
        {
            Vector3 movie = new Vector3(movimento.x, 0, 0) * Time.fixedDeltaTime * deslocamento;
            transform.Translate(movie);
        }
        
        
    }

    private void Awake()
        
    {
        rb = GetComponent<Rigidbody2D>();

         


        
    }

    private void Update()
    {
        

        
        if (jogando == false)
        {
            
            mira.SetActive(false);

        }
        else
        {
            roda1.transform.Rotate(0, 0, -movimento.x * 150 * Time.deltaTime);


            roda2.transform.Rotate(0, 0, -movimento.x * 150 * Time.deltaTime);
            direcao = mira.transform.position;

            controleCanhao();
            mira.SetActive(true);
        }
        

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rio"))
        {
            vida = -99999999;
        }
        vida -= 5;
        if(vida <= 0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("Game");
        }
    }

    void controleCanhao()
    {
        //nosso 90 graus e igual a 0 e nosso 0 graus é -0
        bool chegouLimite = false;

        
        if (canhao.CompareTag("P1"))
        {
            if (canhao.transform.rotation.z >= 0 && movimento.y > 0)
            {
                chegouLimite = true;
                if (chegouLimite && movimento.y < 0)
                {
                    chegouLimite = false;
                }

            }
            if (canhao.transform.rotation.z <= -0.7f && movimento.y < 0)
            {
                chegouLimite = true;
                if (chegouLimite && movimento.y > 0)
                {
                    chegouLimite = false;
                }

            }
        }
        if (canhao.CompareTag("P2"))
        {
            if (canhao.transform.rotation.z <= 0 && movimento.y > 0)
            {
                chegouLimite = true;
                if (chegouLimite && movimento.y < 0)
                {
                    chegouLimite = false;
                }

            }
            
            if (canhao.transform.rotation.z >= 0.7f && movimento.y < 0)
            {
                chegouLimite = true;
                if (chegouLimite && movimento.y > 0)
                {
                    chegouLimite = false;
                }

            }

        }

        if (chegouLimite == false)
        {
            if (canhao.CompareTag("P1"))
            {
                canhao.transform.Rotate(0, 0, movimento.y * speed * Time.deltaTime);

            }
            if (canhao.CompareTag("P2"))
            {
                canhao.transform.Rotate(0, 0, -movimento.y * speed * Time.deltaTime);
            }
        }
    }
}
