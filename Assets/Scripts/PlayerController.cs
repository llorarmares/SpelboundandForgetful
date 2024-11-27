using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 respawnPoint;

    void Start()
    {
        // Establece la posición inicial del respawn (inicio del nivel)
        respawnPoint = new Vector2(-9.55f, -3.53f);

        // Mueve al jugador a la posición inicial del nivel
        transform.position = respawnPoint;
    }

    public void Respawn()
    {
        // Teletransporta al jugador a la posición de respawn
        transform.position = respawnPoint;
        Debug.Log($"Jugador reaparecido en: {respawnPoint}");
    }

    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        // Actualiza el punto de respawn del jugador
        respawnPoint = newRespawnPoint;
        Debug.Log($"Nuevo punto de respawn configurado: {respawnPoint}");
    }
}

