using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Referencia al jugador
    private GameObject player;

    // Posición de respawn por defecto (posición inicial del nivel)
    public Vector2 spawnPoint = new Vector2(-9.55f, -3.53f);

    void Start()
    {
        // Encuentra al jugador en la escena (puedes configurar esto manualmente si tienes más de un jugador)
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Jugador no encontrado. Asegúrate de que el jugador tiene la etiqueta 'Player'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador toca el checkpoint
        if (other.CompareTag("Player"))
        {
            // Actualiza el punto de respawn al llegar al checkpoint
            SetSpawnPoint(transform.position);
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        // Establece un nuevo punto de respawn
        spawnPoint = newSpawnPoint;

        Debug.Log($"Punto de respawn actualizado a: {spawnPoint}");
    }
}

