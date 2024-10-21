using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public PlayerControler p1;
    public PlayerControler p2;
    public GameObject can;
    public TextMeshProUGUI contagem;
    public TextMeshProUGUI vida1;
    public TextMeshProUGUI vida2;

    float deley = 3;
    private bool podeAtirar = false; // Flag para controlar o tiro

    void Start()
    {
        // Define aleatoriamente quem começa
        if (Random.Range(0, 2) == 0)
        {
            StartCoroutine(deleyTroca());
            p1.jogando = true;
            p2.jogando = false;
            p1.jogou = true;
            p2.jogou = false;
        }
        else
        {
            StartCoroutine(deleyTroca());
            p1.jogando = false;
            p2.jogando = true;
            p1.jogou = false;
            p2.jogou = true;
        }
    }

    void Update()
    {
        seguirPlayer();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && podeAtirar) // Verifica se pode atirar
        {
            if (p2.jogando)
            {
                p1.setAtirar();
            }
            else if (p1.jogando)
            {
                p2.setAtirar();
            }
            trocarJogador();
        }
    }

    void seguirPlayer()
    {
        if (p1.jogando)
        {
            vida1.text = " ";
            vida2.text = "Vida: " + p2.vida;
            
            can.transform.position = new Vector3(p2.canhao.transform.position.x-15, p2.canhao.transform.position.y, -20);
        }
        else if (p2.jogando)
        {
            vida2.text = " ";
            vida1.text = "Vida: " + p1.vida;
            can.transform.position = new Vector3(p1.canhao.transform.position.x+15, p1.canhao.transform.position.y, -20);
        }
    }

    IEnumerator deleyTroca()
    {
        podeAtirar = false; // Desativa a habilidade de atirar
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
        podeAtirar = true; // Ativa a habilidade de atirar ao fim da contagem
    }

    void trocarJogador()
    {
        StartCoroutine(deleyTroca()); // Inicia a contagem para a troca
        if (p1.jogou)
        {
            p1.jogando = false;
            p2.jogando = true;
            p1.jogou = false;
        }
        else if (p2.jogou)
        {
            p2.jogando = false;
            p1.jogando = true;
            p2.jogou = false;
        }
    }
}
