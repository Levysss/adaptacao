using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //definir aleatoriamente quem começa 
    public PlayerControler p1;
    public PlayerControler p2;
    public GameObject can;
    
    
    // Start is called before the first frame update
    void Start()
    {
        float primeiroAJogar = Random.Range(0, 1f);
        if (primeiroAJogar >0.5f)
        {
            p1.jogando = true;
            p2.jogando= false;
        }
        if (primeiroAJogar < 0.5f)
        {
            p1.jogando = false;
            p2.jogando = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        seguirPlayer();
        
    }
    void seguirPlayer()
    {
        if (p1.jogando)
        {
            can.transform.position = new Vector3(p1.canhao.transform.position.x, p1.canhao.transform.position.y,-15);
        }
        if (p2.jogando)
        {
            can.transform.position = new Vector3(p2.canhao.transform.position.x, p2.canhao.transform.position.y, -15);
        }
    }
}
