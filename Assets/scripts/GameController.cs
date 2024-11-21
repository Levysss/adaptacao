using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private static GameController instace;
    public PlayerControler p1;
    public PlayerControler p2;
    public GameObject can;  
    public TextMeshProUGUI contagem;
    public TextMeshProUGUI vida1;
    public TextMeshProUGUI vida2;

    private BalaController minhaBala;  
    private bool seguindoBala = false;  
    float deley = 3;
    private bool podeAtirar = false;
    public bool balaExiste = false;
    private float tempoParaAnimacao;

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
        // Decide quem começa primeiro
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

        trocarJogador(); // Troca de jogador após o tiro
    }

    void Update()
    {
        if (seguindoBala && minhaBala != null)
        {
            tempoParaAnimacao = 2;
            balaExiste = true;
            // Segue a bala se ela ainda existir
            can.transform.position = new Vector3(minhaBala.transform.position.x, minhaBala.transform.position.y, -15);
        }
        else
        {

            if (balaExiste)
            {
                balaExiste = false;
                seguindoBala = false;
                StartCoroutine(deleyTroca());
            }
            if (tempoParaAnimacao <= 0)
            {
                
                seguirPlayer();
                
            }
            tempoParaAnimacao -= Time.deltaTime;

            
        }
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

    void seguirPlayer()
    {
        
        if (p1.jogando)
        {
            
            vida1.text = "Vida: " + p1.vida;
            vida2.text = " ";
            can.transform.position = new Vector3(p1.canhao.transform.position.x - 2, p1.canhao.transform.position.y, -15);
        }
        else if (p2.jogando)
        {
            
            vida2.text = "Vida: " + p2.vida;
            vida1.text = " ";
            can.transform.position = new Vector3(p2.canhao.transform.position.x + 2, p2.canhao.transform.position.y, -15);
        }
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
}
