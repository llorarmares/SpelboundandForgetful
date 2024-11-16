using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthcontroller : MonoBehaviour
{
   public static PlayerHealthcontroller instance;
   public int currentHealth, maxHealth;


   private void _Awake ()

   {
    instance = this;
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth--;

        if(currentHealth<=0)
        {
            gameObject.SetActive(false);
        }


    }
}
