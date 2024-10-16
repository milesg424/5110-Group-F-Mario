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


    void CreatCube(Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rd = cube.GetComponent<Renderer>();
       
       
        rd.material = GetComponent<Renderer>().material;
        cube.transform.localScale = transform.localScale / cubesPerAxis;
        Vector3 firstCube = transform.position - cubeScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(position, cube.transform.localScale);
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);

    }
    void show()
    {
       transform.GetChild(0).gameObject.SetActive(true);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            if(type == 1)

            {
                Break();
            }
            if(type == 2)
            {
                show();
            }
        }
    }
}
