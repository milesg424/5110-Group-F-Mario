using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    int TouchCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            print("hit"); 
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
        
      
        if (collision.collider.tag == "Wall")
        {
            TouchCount++;
           if (TouchCount == 3)
            Destroy(gameObject);
        }
        if(collision.collider.tag == "Obstacle")
        {
    
             Destroy(gameObject);
        }
    }
}
