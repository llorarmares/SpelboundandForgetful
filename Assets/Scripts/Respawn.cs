using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint; // Punto de reaparición
    [SerializeField] private float respawnDelay = 1f; // Tiempo antes de reaparecer

    public void PlayerDamaged()
    {
        // Desactiva temporalmente al jugador y llama al respawn
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        // Aquí puedes agregar efectos visuales o sonidos de "muerte"
        gameObject.SetActive(false); // Desactiva al jugador
        yield return new WaitForSeconds(respawnDelay); // Espera el tiempo configurado

        // Reubica al jugador en el punto de reaparición
        transform.position = respawnPoint.position;

        // Reactiva al jugador
        gameObject.SetActive(true);
    }
}

