using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton, sino el Game Manager da error conforme está configurado
    public static GameManager Instance { get; private set; }

    // Texto UI
    public TextMeshProUGUI numBalasText;
    public TextMeshProUGUI numDianasText;
    public TextMeshProUGUI temporizadorText;  // Cuenta regresiva
    public TextMeshProUGUI potenciaText;      // Potencia de disparo
    public TextMeshProUGUI mensajeFinalText;

    // Audios
    public AudioClip musicaVictoria;   // Música de victoria
    public AudioClip musicaDerrota;    // Música de derrota
    public AudioClip musicaImpactoDiana; // Música al golpear una diana
    public AudioClip musicaDisparo;    // Música al disparar una bala
    private AudioSource audioSource;   // El componente de AudioSource

    // Variables de juego
    private int numBalas = 0;
    private int numDianas = 0;
    private float tiempoRestante = 20f; // Tiempo inicial
    private bool juegoEnCurso = true;

    // Referencia al Generador de Dianas
    public GameObject generadorDianas;
    public GameObject cruceta;  // cruceta que desaparecerá al final
    public GameObject botonesUI; // Botones que desaparecerán al final

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
        // Ocultar el mensaje final al inicio
        mensajeFinalText.gameObject.SetActive(false);

        // Actualizar la UI inicial
        ActualizarUI();

        audioSource = GetComponent<AudioSource>();
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
    juegoEnCurso = false; // Detenemos el juego

    // Desactivamos los objetos interactivos
    generadorDianas.SetActive(false);  // Detener la generación de dianas
    cruceta.SetActive(false);          // Detener la cruceta
    botonesUI.SetActive(false);        // Detener los botones UI

    // Mostramos el mensaje final
    mensajeFinalText.gameObject.SetActive(true); // Aseguramos que el mensaje final se muestre

    float precision = (numBalas > 0) ? (numDianas / (float)numBalas) * 100f : 0f;

    mensajeFinalText.text = "Juego Terminado\n" +
                            "Dianas Acertadas: " + numDianas + "\n" +
                            "Balas Disparadas: " + numBalas + "\n" +
                            "Precisión: " + precision.ToString("F2") + "%";

    // Comprobamos si es victoria o derrota
    if (numDianas > 10 && precision > 50f)
    {
        mensajeFinalText.text += "\n¡VICTORIA!";
        ReproducirMusicaVictoria();
    }
    else
    {
        mensajeFinalText.text += "\nDERROTA";
        ReproducirMusicaDerrota();
    }

    Time.timeScale = 0f;
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

    public void ReproducirMusicaVictoria()
    {
        if (audioSource != null && musicaVictoria != null)
        {
            audioSource.clip = musicaVictoria;
            audioSource.Play();
        }
    }

    public void ReproducirMusicaDerrota()
    {
        if (audioSource != null && musicaDerrota != null)
        {
            audioSource.clip = musicaDerrota;
            audioSource.Play();
        }
    }

    public void ReproducirMusicaImpactoDiana()
    {
        if (audioSource != null && musicaImpactoDiana != null)
        {
            audioSource.clip = musicaImpactoDiana;
            audioSource.Play();
        }
    }

    public void ReproducirMusicaDisparo()
    {
        if (audioSource != null && musicaDisparo != null)
        {
            audioSource.clip = musicaDisparo;
            audioSource.Play();
        }
    }

}
