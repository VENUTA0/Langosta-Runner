using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject panelInicio;

    private static bool yaEmpezo = false;

    void Awake()
    {
        panelGameOver.SetActive(false);

        if (yaEmpezo)
        {
            panelInicio.SetActive(false);
            Time.timeScale = 1f;
        }
        else //primera vez que abres el juego
        {
            panelInicio.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PerderJuego();
        }
    }
    public void EmpezarJuego()
    {
        yaEmpezo = true;
        panelInicio.SetActive(false);
        Time.timeScale = 1f;
    }
    void PerderJuego()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}