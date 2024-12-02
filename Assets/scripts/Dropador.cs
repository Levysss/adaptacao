using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropador : MonoBehaviour
{
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,22);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right *Time.deltaTime*5;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(box,transform.position,Quaternion.identity);
    }
}
