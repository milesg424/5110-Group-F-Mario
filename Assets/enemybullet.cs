using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            
            
            Destroy(gameObject);
        }


        if (collision.collider.tag == "Wall" || collision.collider.tag =="Enemy" || collision.collider.tag == "Obstacle")
        {
         
                Destroy(gameObject);
        }
       
    }
}
