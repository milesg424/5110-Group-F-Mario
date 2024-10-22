using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Vector3 loc;
    public Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            speed = new Vector3(-0.01f,0f,0f);

        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            col.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
