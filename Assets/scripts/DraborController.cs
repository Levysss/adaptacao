using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraborController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GetInstance().balaExiste == true)
        {
            //Destroy(gameObject,2);
        }
    }
    
}
