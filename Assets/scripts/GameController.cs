using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public PlayerControler p1;
    public PlayerControler p2;
    public GameObject can;
    public TextMeshProUGUI contagem;

    float deley = 3.5f;

    void Start()
    {
        // Define aleatoriamente quem começa
        if (Random.Range(0, 2) == 0)
        {
            p1.jogando = true;
            p2.jogando = false;
            p1.jogou = true;
            p2.jogou = false;
        }
        else
        {
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
        if (context.performed)
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
            can.transform.position = new Vector3(p2.canhao.transform.position.x, p2.canhao.transform.position.y, -15);
        }
        else if (p2.jogando)
        {
            can.transform.position = new Vector3(p1.canhao.transform.position.x, p1.canhao.transform.position.y, -15);
        }
    }

    void trocarJogador()
    {
        if (p1.jogou)
        {
            p1.jogando = false;
            while (deley>0)
            {
                deley = deley - Time.deltaTime;
                int numero = (int)deley;
                contagem.text = numero.ToString();

            }
            deley = 3.5f;
            p2.jogando = true;
            p1.jogou = false;
        }
        else if (p2.jogou)
        {
            p2.jogando = false;
            while (deley > 0)
            {
                Debug.Log("Entrou");
                deley = deley - Time.deltaTime;
                int numero = (int)deley;
                contagem.text = numero.ToString();

            }
            deley = 3.5f;
            p1.jogando = true;
            p2.jogou = false;
        }
    }
}
