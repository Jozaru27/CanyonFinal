using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    // Texto UI
    public TextMeshProUGUI numBalasText;
    public TextMeshProUGUI numDianasText;
    public TextMeshProUGUI temporizadorText;  // Cuenta regresiva
    public TextMeshProUGUI potenciaText;      // Potencia de disparo
    public TextMeshProUGUI mensajeFinalText;

    // Variables de juego
    private int numBalas = 0;
    private int numDianas = 0;
    private float tiempoRestante = 20f; // Tiempo inicial
    private bool juegoEnCurso = true;

    // Referencia al Generador de Dianas
    public GameObject generadorDianas;

    void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }

    void Start()
    {
        ActualizarUI();
    }

    void Update()
    {
        if (juegoEnCurso)
        {
            // Reducir el tiempo restante
            tiempoRestante -= Time.deltaTime;
            temporizadorText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                FinDelJuego();
            }
        }
    }

    public void DianaAcertada()
    {
        numDianas++;
        tiempoRestante += 3f; // Añadir tiempo extra al acertar una diana
        ActualizarUI();
    }

    public void BalaDisparada()
    {
        numBalas++;
        ActualizarUI();
    }

    public void DecNumBalas()
    {
        if (numBalas > 0)
        {
            numBalas--;
            ActualizarUI();
        }
    }

    void ActualizarUI()
    {
        numBalasText.text = "Balas Disparadas: " + numBalas;
        numDianasText.text = "Dianas Acertadas: " + numDianas;
    }

    void FinDelJuego()
    {
        juegoEnCurso = false;
        generadorDianas.SetActive(false);

        float precision = (numBalas > 0) ? (numDianas / (float)numBalas) * 100f : 0f;

        mensajeFinalText.text = "Juego Terminado\n" +
                                "Dianas Acertadas: " + numDianas + "\n" +
                                "Balas Disparadas: " + numBalas + "\n" +
                                "Precisión: " + precision.ToString("F2") + "%";

        if (numDianas > 10 && precision > 50f)
        {
            mensajeFinalText.text += "\n¡VICTORIA!";
            MostrarAnimacionVictoria();
        }
        else
        {
            mensajeFinalText.text += "\nDERROTA";
            MostrarAnimacionDerrota();
        }
    }

    void MostrarAnimacionVictoria()
    {
        Debug.Log("Animación de Victoria");
    }

    void MostrarAnimacionDerrota()
    {
        Debug.Log("Animación de Derrota");
    }

    // Método para actualizar la potencia
    public void UpdatePotencia(float tiempoPulsadoVar)
    {
        if (potenciaText != null) // Asegurarse de que el texto está asignado
        {
            potenciaText.text = "Potencia: " + tiempoPulsadoVar.ToString("F2"); // Mostrar la potencia
        }
    }

    // Incrementar el número de balas
    public void IncNumBalas()
    {
        numBalas++;
        ActualizarUI();
    }
}
