using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canyon : MonoBehaviour
{

    public Transform Cruceta; 
    public Transform PuntoDeDisparo;
    public float rotacionVelocidad = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direccion = Cruceta.position - PuntoDeDisparo.position;  // Calcula la dirección desde la punta
        //Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion); // Crea la rotación hacia la cruceta
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, rotacionVelocidad * Time.deltaTime); // Rota suavemente
        
    }
    
}
