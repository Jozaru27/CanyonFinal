using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{

    private int impactosDiana = 0;     // Contador de impactos
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {   
        // Buscar el GameManager por su nombre
        GameObject gmObject = GameObject.Find("==GameManager==");
        gameManager = gmObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Método cuando ocurre una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // YA NO - (opcional) verificar si el objeto que colisionó tiene la etiqueta "Bala" //tocó cambiar el colision detection a continuous
        // cada vez que las colisiones chocan, aumenta el número de impactos. llama a la función Mover Diana.
        if (collision.gameObject.CompareTag("Bala")){

            impactosDiana++;

            Destroy(collision.gameObject);
            GameManager.DecNumBalas();

            gameManager.MoverDiana();
        }
    }
}
