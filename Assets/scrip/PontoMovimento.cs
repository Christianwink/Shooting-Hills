using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoMovimento : MonoBehaviour
{
    private Vector3 posiincial;
    private float distancia;
    public GameObject gereciador;
    private Rigidbody rb;

    private void Start()
    {
        posiincial = transform.position;

        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        distancia = Vector3.Distance(posiincial, transform.position);
        if (rb.velocity.x >= 1 || rb.velocity.y >= 1 || rb.velocity.z >= 1)
        {
            gereciador.GetComponent<GerenciadorScrip>().pontacao += distancia; 
        }
        
    }

    
}
