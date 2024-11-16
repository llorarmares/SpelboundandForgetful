using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con imágenes y sprites.

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3; 
    public Sprite hearthFull; 
    public Sprite hearthEmpty; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

   
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth) 
        {
            case 3:
                heart1.sprite = hearthFull;
                heart2.sprite = hearthFull;
                heart3.sprite = hearthFull;
                break;

            case 2:
                heart1.sprite = hearthFull;
                heart2.sprite = hearthFull;
                heart3.sprite = hearthEmpty;
                break;

            case 1:
                heart1.sprite = hearthFull;
                heart2.sprite = hearthEmpty;
                heart3.sprite = hearthEmpty;
                break;

            case 0:
                heart1.sprite = hearthEmpty;
                heart2.sprite = hearthEmpty;
                heart3.sprite = hearthEmpty;
                break;

            default:
                Debug.LogWarning("Health value out of range!");
                break;
        }
    }
}
