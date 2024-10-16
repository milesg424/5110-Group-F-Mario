using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float time;
    public float moveDistance;
    private Vector3 Loc1;
    private Vector3 Loc2;
    private bool reachLoc1;
    private bool reachLoc2;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        Loc1=transform.position;
        Loc1.x -= moveDistance;
        Loc2 = transform.position;
        Loc2.x += moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
       if( reachLoc1)
        {
            time += speed;
        }
        if (reachLoc2)
        {
            time -= speed;
        }

        if (time >= 1)
        {
            reachLoc2 = true;
            reachLoc1 = false;
        }
        else if (time <= 0)
        {
            reachLoc2 = false;
            reachLoc1 = true;
        }

        
        if(canMove)
        {
            transform.position = Vector3.Lerp(Loc1, Loc2, time);
        }
       
    }

    public void Kill()
    {

        canMove = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Destory());
    }
    IEnumerator Destory()
    {
       
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    
}
