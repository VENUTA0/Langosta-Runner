using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float fuerza = 50f;         
    [SerializeField] private float desvioLateral = 0.3f; // Desvío 
    [SerializeField] private float giro = 5f;            // Fuerza de rotación aleatoria
    [SerializeField] private float limiteZ = -5f;        // Donde desaparece

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float desvioX = Random.Range(-desvioLateral, desvioLateral);
        float desvioY = Random.Range(-desvioLateral, desvioLateral);

        Vector3 direccion = Vector3.back + new Vector3(desvioX, desvioY, 0f);

        rb.AddForce(direccion * fuerza, ForceMode.Impulse);
        Vector3 giroAleatorio = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        rb.AddTorque(giroAleatorio * giro, ForceMode.Impulse);
    }

    void Update()
    {
        ComprobarDestruccion();
    }


    private void ComprobarDestruccion()
    {
        if (transform.position.z < limiteZ)
        {
            Destroy(gameObject);
        }
    }
}
