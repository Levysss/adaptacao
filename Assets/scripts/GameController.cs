using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
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

        StartCoroutine(deleyTroca());
    }

    void Update()
    {
        if (seguindoBala && minhaBala != null)
        {
            // Segue a bala se ela ainda existir
            can.transform.position = new Vector3(minhaBala.transform.position.x, minhaBala.transform.position.y, -5);
        }
        else
        {
            // Se a bala for destruída, volta a seguir o jogador
            seguindoBala = false;
            seguirPlayer();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && podeAtirar)
        {
            if (p1.jogando)
            {
                p1.setAtirar();
                minhaBala = p1.GetBala();  
                seguindoBala = true;  
                trocarJogador();
            }
            else if (p2.jogando)
            {
                p2.setAtirar();
                minhaBala = p2.GetBala();  
                seguindoBala = true;  
                trocarJogador();
            }
        }
    }

    void seguirPlayer()
    {
        if (p1.jogando)
        {
            vida1.text = "Vida: " + p1.vida;
            vida2.text = " ";
            can.transform.position = new Vector3(p1.canhao.transform.position.x + 15, p1.canhao.transform.position.y, -20);
        }
        else if (p2.jogando)
        {
            vida2.text = "Vida: " + p2.vida;
            vida1.text = " ";
            can.transform.position = new Vector3(p2.canhao.transform.position.x - 15, p2.canhao.transform.position.y, -20);
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

        StartCoroutine(deleyTroca());
    }
}
