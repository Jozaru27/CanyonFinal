using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DispararCanyonazo : MonoBehaviour
{
    GameObject posInicial;
    GameObject posFinal;
    GameObject canyon;

    public GameObject prefabBala;
    GameObject balaInstanciada;
    float distancia;
    public Material materialInstanciado; //necesario para poder cambiar el material del objeto
    public Transform objetoPadre; 
    
    // Al inicio del Script
    void Start(){
        posInicial = GameObject.Find("PuntoDeDisparo");         // De donde sale la bala
        posFinal = GameObject.Find("Cruceta");                  // A donde apunta la bala
        canyon = GameObject.Find("Cuerpo");                     // Nombre del objeto del cañón (Cilindro en la escena)
    }

    // Actualiza el script cada frame
    void Update(){
        // Si la bala no es nula (o sea, que está instanciada)
        if (balaInstanciada != null) {
            // calcular la distancia entre la bala y el cañón
            distancia = Vector3.Distance(balaInstanciada.transform.position, canyon.transform.position);

            // Obtener el Renderer del cañón (Para acceder al material)
            Renderer renderer = canyon.GetComponent<Renderer>();

            // Cambiar el color del cañón si la bala está cerca
            if (distancia < 10f){
                renderer.material.color = Color.red;
            } else {
                renderer.material = materialInstanciado;
            }
        }
    }


    private void OnMouseDown(){
        // Instanciar la bala
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

        balaInstanciada.name = "Bala"; // !!! 

        balaInstanciada.transform.SetParent(objetoPadre);
        
        // genera un tamañoa aleatorio y se lo asigna a la bala
        float tamañoAleatorio = Random.Range(0.5f, 3.0f);
        balaInstanciada.transform.localScale = new Vector3(tamañoAleatorio, tamañoAleatorio, tamañoAleatorio);

        // necesario para mantener las físicas
        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();

        // genera una fuerza aleatoria y se la asigna a la bala
        float fuerzaAleatoria = Random.Range(25f, 100f);
        // calcula la direccion de disparo
        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;

        // fuerza
        rb.AddForce(direccion * fuerzaAleatoria, ForceMode.Impulse);

        // color aleatorio
        Color[] colores = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.black };
        Renderer renderer = balaInstanciada.GetComponent<Renderer>();
        renderer.material.color = colores[Random.Range(0, colores.Length)];

        // Avisar al GameManager para aumentar el número de balas
        GameManager.IncNumBalas();
    }
}

// 5 colores básicos?