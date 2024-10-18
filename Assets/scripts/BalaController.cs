using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myRb;
    public PlayerControler player;
    private float speed = 5;

    void Start()
    {

        player = FindAnyObjectByType<PlayerControler>();
        
        
        
        myRb = GetComponent<Rigidbody2D>();
        Vector2 posicaoCanhao = player.canhao.transform.position;
        Vector2 direcao = player.direcao - posicaoCanhao;
        myRb.velocity = direcao *speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
