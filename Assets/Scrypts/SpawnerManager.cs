using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] listaObstaculos; //Este array me permitira arrastrar los obstaculos en unity
    [SerializeField] private float tiempoEntreObstaculos = 2f; 

    [SerializeField] private float minX = -9f; //mismos limites de movimiento que la langosta
    [SerializeField] private float maxX = 9f;
    [SerializeField] private float minY = 4f;
    [SerializeField] private float maxY = 16f;

    [SerializeField] private float spawnZ = 250f; 

    void Start()
    {
        InvokeRepeating("GenerarObstaculo", 1f, tiempoEntreObstaculos); //invoca el metodo 1 segundo despues de empezar, y cada 2 segs (tiempoentreobstaculos)
    }

    void Update()
    {

    }
        private void GenerarObstaculo()
    {
        int indiceAleatorio = Random.Range(0, listaObstaculos.Length); // elige el numero aleatorio del objeto que saldrá del array entre 0 y 4

        float randomX = Random.Range(minX, maxX); //los limites de movimiento de la langosta
        float randomY = Random.Range(minY, maxY);
        Vector3 posicionSpawn = new Vector3(randomX, randomY, spawnZ); // esta es la coordenada donde aparecerá

        Instantiate(listaObstaculos[indiceAleatorio], posicionSpawn, listaObstaculos[indiceAleatorio].transform.rotation); //el num del obstaculo, la posicion aleatoria y con quaternion identity se usa la rotacion original del prefabv
    }
}

