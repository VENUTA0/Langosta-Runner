using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReciclajeEscenario : MonoBehaviour
{
    private float speedescenario = -100f;
    private float fueradecam = -250f;

    void Start()
    {
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        transform.Translate(Vector3.forward * speedescenario * Time.deltaTime);
        if (transform.position.z <= fueradecam)
            transform.position += new Vector3(0f, 0f, 1000f); 
    }
}
