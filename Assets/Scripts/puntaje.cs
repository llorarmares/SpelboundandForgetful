using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        // Buscar componente en el GameObject o sus hijos
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        // Verificar si se encontró el componente
        if (textMeshProUGUI == null)
        {
            Debug.LogError("TextMeshProUGUI no encontrado. Asegúrate de que el GameObject tiene el componente.");
            return;
        }

        // Inicializar el texto con el puntaje máximo guardado
        textMeshProUGUI.text = PlayerPrefs.GetInt("PuntajeMaximo").ToString();

        // Suscribirse al evento SumarPuntosEvent del controlador
        if (ControladorPuntos.Instance != null)
        {
            ControladorPuntos.Instance.SumarPuntosEvent += CambiarTexto;
        }
    }

    void CambiarTexto(object sender, ControladorPuntos.SumarPuntosEventArgs e)
    {
        if (textMeshProUGUI != null)
        {
            // Usar las propiedades correctas del evento
            textMeshProUGUI.text = e.PuntajeActualEvnt.ToString();
        }
    }
}


