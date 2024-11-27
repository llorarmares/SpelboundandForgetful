using System;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance { get; private set; }

    private int puntajeActual;
    public int puntajeMaximo;

    // Definición del evento
    public event EventHandler<SumarPuntosEventArgs> SumarPuntosEvent;

    // Clase para pasar los datos del evento
    public class SumarPuntosEventArgs : EventArgs
    {
        public int PuntajeActualEvnt { get; set; }
        public int PuntajeMaximoEvnt { get; set; }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
    }

    // Método público para sumar puntos
    public void SumarPuntos(int puntos)
    {
        puntajeActual += puntos;

        if (puntajeActual > puntajeMaximo)
        {
            puntajeMaximo = puntajeActual;
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeMaximo);
        }

        // Lanza el evento
        SumarPuntosEvent?.Invoke(this, new SumarPuntosEventArgs
        {
            PuntajeActualEvnt = puntajeActual,
            PuntajeMaximoEvnt = puntajeMaximo
        });
    }

    public int PuntajeActual => puntajeActual;
    public int PuntajeMaximo => puntajeMaximo;
}


