using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 35;
    private Rigidbody2D myRb;
    public Vector3 minhaPosicao;


    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
