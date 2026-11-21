using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorDistancia : MonoBehaviour
{
    public TextMeshProUGUI textoEnJuego;   
    public TextMeshProUGUI textoGameOver;  
    public float velocidadMetros = 10f;    

    private float distancia = 0f;

    void Start() 
    {
        distancia = 0f;
        textoEnJuego.text = "0 m";
        textoEnJuego.gameObject.SetActive(false);
        
    }
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            textoEnJuego.gameObject.SetActive(false); 
            return;
        }

        textoEnJuego.gameObject.SetActive(true);
        if (Time.deltaTime > 0.1f) return;

        distancia += Time.deltaTime * velocidadMetros;

        string textoFormateado = Mathf.FloorToInt(distancia) + " m";
        textoEnJuego.text = textoFormateado;
        textoGameOver.text = "Distancia: " + textoFormateado;
    }
}
