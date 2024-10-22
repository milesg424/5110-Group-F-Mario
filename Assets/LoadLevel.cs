using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string lv;
    public string removelv;
    
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.FindGameObjectsWithTag(lv)[0].SetActive(true);
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = GameObject.FindGameObjectsWithTag("Spawn")[0].transform.position;
            foreach (Transform child in GameObject.FindGameObjectsWithTag(lv)[0].transform)
            {
                child.gameObject.SetActive(true);
            }
            GameObject.FindGameObjectsWithTag(removelv)[0].SetActive(false);
        }
       
    }
}
