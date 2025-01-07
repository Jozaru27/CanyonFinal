using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCruceta : MonoBehaviour
{
    public float velocidadMovimientoCruceta = 15f; 
    public Vector2 limitesY = new Vector2(3.5f, 9f); // Límites para el eje Y
    public Vector2 limitesZ = new Vector2(-7.5f, 7.5f); // Límites para el eje Z

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A D 🡠 🡢
        float vertical = Input.GetAxis("Vertical");     // W S 🡡 🡣

        // Calcula y aplica movimiento en Y y Z
        Vector3 movement = new Vector3(0, vertical, horizontal) * velocidadMovimientoCruceta * Time.deltaTime;
        transform.position += movement;

        // Limita la posición de la cruceta (a partir de las variables inicializadas al principio)
        float clampedY = Mathf.Clamp(transform.position.y, limitesY.x, limitesY.y);
        float clampedZ = Mathf.Clamp(transform.position.z, limitesZ.x, limitesZ.y); 

        // Actualiza la posición con los límites
        transform.position = new Vector3(transform.position.x, clampedY, clampedZ);
    }
}
