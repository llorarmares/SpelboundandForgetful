using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _OnTriggerEnter2D (Collider2D other)
{
   if (other.tag == "Player")
   {
      PlayerHealthcontroller.instance.DealDamage();

   }

}
}
