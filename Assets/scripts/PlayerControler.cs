using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public int vida = 100;
    private Rigidbody2D rb;

    public GameObject roda1;
    public GameObject roda2;
    public GameObject canhao;
    public GameObject bocaCanhao;

    public bool jogando;
    public string nomeBala = "normal";
    public GameObject[] minhaBala;
    public GameObject balaAtiva;
    public GameObject mira;
    public Vector2 direcao;
    private float energia = 1;
    private float gazoza = 60;

    private BalaController balaController;


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
        gazoza = 60;
        energia = 1;
        if (jogando && !jogou)
        {
            
            if (nomeBala =="normal")
            {
                balaAtiva = Instantiate(minhaBala[0], bocaCanhao.transform.position, canhao.transform.rotation);
            }
            else if (nomeBala == "mega")
            {
                balaAtiva = Instantiate(minhaBala[1], bocaCanhao.transform.position, canhao.transform.rotation);
                nomeBala = "normal";
            }else if (nomeBala == "gost")
            {
                balaAtiva = Instantiate(minhaBala[2], bocaCanhao.transform.position, canhao.transform.rotation);
                nomeBala = "normal";
            }
            
            balaController = balaAtiva.GetComponentInParent<BalaController>();
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
        if (GameController.GetInstance().balaExiste == false) 
        {
            movimentacao();
        }
        
    }

    private void Awake()
        
    {
        rb = GetComponent<Rigidbody2D>();
        
         


        
    }

    
    private void movimentacao() 
    {

        if (jogando)
        {

            if (movimento.x != 0)
            {
                if (movimento.x > 0)
                {
                    gazoza -= movimento.x;
                }
                else if (movimento.x < 0)
                {
                    gazoza -= -movimento.x;
                }

                if (gazoza <= 0)
                {
                    energia = 0;
                }
            }

            Vector3 movie = new Vector3(movimento.x, 0, 0) * Time.fixedDeltaTime * deslocamento * energia;
            transform.Translate(movie);
            roda1.transform.Rotate(0, 0, -movimento.x * 150 * Time.fixedDeltaTime * energia);


            roda2.transform.Rotate(0, 0, -movimento.x * 150 * Time.fixedDeltaTime * energia);
            direcao = mira.transform.position;

            controleCanhao();
            mira.SetActive(true);

        }
        else if (jogando == false)
        {
            mira.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rio"))
        {
            vida = -99999999;
        }
        //Debug.Log(balaController.dano);
        vida -= (int)balaController.dano;
        if(vida <= 0)
        {
           
            SceneManager.LoadScene("Game");
        }
    }
    public void ReceberDano(int dano)
    {
        vida -= dano;
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
