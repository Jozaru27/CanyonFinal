using UnityEngine;

public class MovimientoCruceta : MonoBehaviour
{
    public float velocidadMovimientoCruceta = 15f;

    // Límites de movimiento (directamente asignados)
    private float limiteYMin = 2f;
    private float limiteYMax = 10f;
    private float limiteZMin = -27f;
    private float limiteZMax = 30f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral
        float vertical = Input.GetAxis("Vertical");     // Movimiento vertical

        // Calcula y aplica movimiento en Y y Z
        Vector3 movement = new Vector3(0, vertical, horizontal) * velocidadMovimientoCruceta * Time.deltaTime;
        transform.position += movement;

        // Limita la posición de la cruceta con los valores asignados
        float clampedY = Mathf.Clamp(transform.position.y, limiteYMin, limiteYMax);
        float clampedZ = Mathf.Clamp(transform.position.z, limiteZMin, limiteZMax);

        // Actualiza la posición con los límites
        transform.position = new Vector3(transform.position.x, clampedY, clampedZ);
    }
}
