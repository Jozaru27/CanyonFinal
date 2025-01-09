using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GneradorDianas : MonoBehaviour
{
    public GameObject dianaPrefab; // Prefab de la diana
    public float posicionX = -4f; // Posición fija en X
    public float limiteYMin = 2f;
    public float limiteYMax = 10f;
    public float limiteZMin = -20f;
    public float limiteZMax = 30f;

    public float intervaloGeneracion = 2f; // Tiempo entre la aparición de nuevas dianas

    private float temporizador;

    void Start()
    {
        temporizador = intervaloGeneracion; // Iniciar el temporizador con el intervalo
    }

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador <= 0)
        {
            GenerarDiana();
            temporizador = intervaloGeneracion; // Reiniciar el temporizador
        }
    }

    void GenerarDiana()
    {
        // Generar una posición aleatoria dentro de los límites
        float yAleatorio = Random.Range(limiteYMin, limiteYMax);
        float zAleatorio = Random.Range(limiteZMin, limiteZMax);
        Vector3 posicionAleatoria = new Vector3(posicionX, yAleatorio, zAleatorio);

        // Instanciar diana
        Instantiate(dianaPrefab, posicionAleatoria, Quaternion.Euler(0, 90, 0));
    }
}
