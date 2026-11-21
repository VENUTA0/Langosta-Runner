using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float limitMaxX = 9f;
    [SerializeField] private float limitMinX = -9f;

    [SerializeField] private float limitMaxY = 16f;
    [SerializeField] private float limitMinY = 4f;

    [SerializeField] private float origenRotacion = 0f;
    [SerializeField] private float speedRotacion = 10f;


    void Start()
    {
    }

    void Update()
    {
        if (Time.timeScale == 0f) return; // <--- AÑADIR ESTO


        Movimiento();
        RotarNave();
        LimiteMovimento(); 
    }

private void Movimiento()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(inputHorizontal, inputVertical, 0f);

        transform.Translate(direccion * speed * Time.deltaTime, Space.World);
    }

    private void RotarNave()
    {
        float direccionX = Input.GetAxis("Horizontal");

        origenRotacion = Mathf.Lerp(origenRotacion, -direccionX * 30f, speedRotacion * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, origenRotacion);
    }
    private void LimiteMovimento()
    {
        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, limitMinX, limitMaxX);
        posicionActual.y = Mathf.Clamp(posicionActual.y, limitMinY, limitMaxY);

        transform.position = posicionActual;
    }
}
