using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoContoller : MonoBehaviour
{
    private float tempoexposao= 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoexposao <= 0) 
        {
            Destroy(gameObject);
        }
        tempoexposao -= Time.deltaTime;
    }
}
