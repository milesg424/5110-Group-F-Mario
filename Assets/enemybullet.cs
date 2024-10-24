using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    int TouchCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Wall")
        {
            TouchCount++;
            if (TouchCount == 3)
                Destroy(gameObject);
        }
        if (collision.GetComponent<Collider2D>().tag == "Obstacle")
        {

            Destroy(gameObject);
        }


    }
    IEnumerator SetCollision()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
    }
    public void collision()
    {
        StartCoroutine(SetCollision());
    }
}
