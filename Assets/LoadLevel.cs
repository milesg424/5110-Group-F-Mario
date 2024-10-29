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
        {    if(removelv == "Level1") { 
            GameObject.FindGameObjectsWithTag(lv)[0].SetActive(true);
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = GameObject.FindGameObjectsWithTag("Spawn")[0].transform.position;
            foreach (Transform child in GameObject.FindGameObjectsWithTag(lv)[0].transform)
            {
                child.gameObject.SetActive(true);
            }
            GameObject.FindGameObjectsWithTag(removelv)[0].SetActive(false);
        }
        if(removelv == "Level2")
            {
                
                GameObject.FindGameObjectsWithTag("Start")[0].SetActive(false);
                GameObject.FindGameObjectsWithTag("End")[0].transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectsWithTag("End")[0].transform.GetChild(1).gameObject.SetActive(true);
               
               
                GameObject.FindGameObjectsWithTag("Level2")[0].SetActive(false);
            }
        }
    }
}
