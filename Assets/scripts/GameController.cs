using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameController : MonoBehaviour
{
    private static GameController instace;
    public PlayerControler p1;
    public PlayerControler p2;
    public GameObject can;  
    public TextMeshProUGUI contagem;
    public TextMeshProUGUI vida1;
    public TextMeshProUGUI vida2;
    public Slider barra1;
    public Slider barra2;
    private BalaController minhaBala;  
    private bool seguindoBala = false;  
    float deley = 3;
    private bool podeAtirar = false;
    public bool balaExiste = false;
    private float tempoParaAnimacao;
    private Vector2 moviCan;
    public Animator item;
    private bool mina= false;
    private bool minaColidiu = false;
    private void Awake()
    {
        instace = this;
    }
    public static GameController GetInstance() 
    {
        return instace; 
    }

    void Start()
    {
        // Decide quem come�a primeiro
        if (Random.Range(0, 2) == 0)
        {
            p2.jogando = true;
            p1.jogando = false;
            
        }
        else
        {
            p1.jogando = true;
            p2.jogando = false;
            
        }
        podeAtirar = true;
        AtirarPrimeiro();
        StartCoroutine(deleyTroca());
    }
    void AtirarPrimeiro()
    {
        if (p1.jogando)
        {
            p1.setAtirar();
            minhaBala = p1.GetBala();
            seguindoBala = true;
        }
        else if (p2.jogando)
        {
            p2.setAtirar();
            minhaBala = p2.GetBala();
            seguindoBala = true;
        }

        trocarJogador(); // Troca de jogador ap�s o tiro
    }

    void Update()
    {
        vidaTempoReal();
        itemAtual();
        if (seguindoBala && minhaBala != null)
        {
            tempoParaAnimacao = 2;
            balaExiste = true;
            // Segue a bala se ela ainda existir
            can.transform.position = new Vector3(minhaBala.transform.position.x, minhaBala.transform.position.y, -15);
            if(minhaBala.nome == "mina")
            {
                
                mina = true;
                if (minhaBala.colidiu)
                {
                    
                    minaColidiu = true;
                    minhaBala = null;
                }
            }
        }
        else
        {
            
            
            if (balaExiste)
            {
                balaExiste = false;
                seguindoBala = false;
                if (mina && minaColidiu)
                {
                    balaExiste = false;
                    seguindoBala = false;
                    StartCoroutine(deleyTroca());
                }
                StartCoroutine(deleyTroca());
            }
            
            if (tempoParaAnimacao <= 0)
            {
                
                seguirPlayer();
                
            }
            tempoParaAnimacao -= Time.deltaTime;

            
        }
    }

    public void setDeslocamento(InputAction.CallbackContext valui)
    {
        moviCan = valui.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && podeAtirar && balaExiste == false)
        {
            if (p1.jogando)
            {
                p1.setAtirar();
                minhaBala = p1.GetBala();
                trocarJogador();
                seguindoBala = true;  
                
            }
            else if (p2.jogando)
            {
                p2.setAtirar();
                minhaBala = p2.GetBala();
                trocarJogador();
                seguindoBala = true;  
                
            }
        }
    }
    void vidaTempoReal()
    {
        vida1.text = "" + p1.vida;
        //vida2.text = " ";
        barra1.value = p1.vida;

        barra2.value = p2.vida;
        vida2.text = "" + p2.vida;
    }
    void seguirPlayer()
    {
        //Debug.Log(moviCan.x);
        float offset = 2;
        offset += moviCan.x * 35;
        Vector3 destino= Vector3.zero;
        if (p1.jogando)
        {
            
            
            
            destino = new Vector3(p1.canhao.transform.position.x + offset, p1.canhao.transform.position.y, -15);
        }
        else if (p2.jogando)
        {
            
            //vida1.text = " ";
            destino = new Vector3(p2.canhao.transform.position.x + offset, p2.canhao.transform.position.y, -15);
        }
        can.transform.position = Vector3.Lerp(can.transform.position, destino, Time.deltaTime);
    }

    IEnumerator deleyTroca()
    {
        
        podeAtirar = false;
        float tempoRestante = deley;
        while (tempoRestante > 0)
        {
            int numero = Mathf.CeilToInt(tempoRestante);
            contagem.text = numero.ToString();
            yield return new WaitForSeconds(1f);
            tempoRestante -= 1;
        }
        contagem.text = "Vai!";
        yield return new WaitForSeconds(0.5f);
        contagem.text = "";
        podeAtirar = true;
        
    }
    
    void trocarJogador()
    {
        if (p1.jogando)
        {
            p1.jogando = false;
            p2.jogando = true;
        }
        else if (p2.jogando)
        {
            p2.jogando = false;
            p1.jogando = true;
        }

        
    }
    void itemAtual()
    {
        if (p1.jogando)
        {
            switch (p1.nomeBala)
            {
                case "normal":
                    item.Play("normal");
                    break;
                case "mega":
                    item.Play("mega");
                    break;
                case "gost":
                    item.Play("gost");
                    break;
                case "mina":
                    item.Play("mina");
                    break;

            }
        }
        else if (p2.jogando)
        {
            switch (p2.nomeBala)
            {
                case "normal":
                    item.Play("normal");
                    break;
                case "mega":
                    item.Play("mega");
                    break;
                case "gost":
                    item.Play("gost");
                    break;
                case "mina":
                    item.Play("mina");
                    break;

            }
        }
    }
}
