using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GeradorDroper : MonoBehaviour
{
    public GameObject dropador;
    public float tempo = 8;
    private float conserva;
    // Start is called before the first frame update
    void Start()
    {

        conserva = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tempo <= 0)
        {
            Instantiate(dropador, transform.position, quaternion.identity);
            tempo = conserva;
        }
        tempo -= Time.deltaTime;
    }
}
