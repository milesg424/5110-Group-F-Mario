using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int cubesPerAxis = 10;
    public float delay = 1f;
    public float force = 300f;
    public float radius = 2f;
    public Vector3 cubeScale;
    public int type;
    public GameObject brick;
    public void Break()
    {
        GetComponent<Renderer>().enabled = false;
    
        for (int i = 0; i < cubesPerAxis; i++)
        {
            for (int j = 0; j < cubesPerAxis; j++)
            {
                for (int k = 0; k < cubesPerAxis; k++)
                {
                    CreatCube(new Vector3(i, j, k));
                }
            }
        }
        Destroy(gameObject);
    }
    public void Break1()
    {
        GetComponent<Renderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }

    void CreatCube(Vector3 position)
    {
        GameObject cube = Instantiate(brick, transform.position, Quaternion.identity, null);


        cube.transform.localScale = transform.localScale / cubesPerAxis;
        Vector3 firstCube = transform.position - cubeScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = Vector3.Scale(position, cube.transform.localScale);
        cube.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,100));

    }
    void show()
    {
       transform.GetChild(0).gameObject.SetActive(true);
       transform.GetChild(1).gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>().GrowUp = true;
    }
    void shoot()
    {
        show();
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>().canShoot = true;
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>().GrowUp = true;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            if(type == 1)

            {
                Break1();
            }
            if(type == 2)
            {
                show();
            }
            if(type == 3)
            {
                shoot();
            }
        }
    }
}
