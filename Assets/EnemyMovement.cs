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
    private Vector3 Loc3;
    private Vector3 Loc4;
    private bool reachLoc1;
    private bool reachLoc2;
    private bool canMove = true;
    public int type;
    private float time1;
    public float bulletcooldown;
    public GameObject bullet;
    public GameObject spawnbullet;
    // Start is called before the first frame update
    void Start()
    {
        Loc1 = transform.position;
        Loc1.x -= moveDistance;
        Loc2 = transform.position;
        Loc2.x += moveDistance;

    }

    // Update is called once per frame
    void Update()
    {
        if(type == 2)
        {
            time1 += Time.deltaTime;
            if(time1 >= bulletcooldown)
            {
                time1 = 0;
                Instantiate(bullet, spawnbullet.transform.position, Quaternion.identity, null);
            }
        }
        if (type == 3)
        {
            time1 += Time.deltaTime;
            if (time1 >= bulletcooldown)
            {
                time1 = 0;
                Attack();
            }
        }
        if ( reachLoc1)
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
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (time <= 0)
        {
            reachLoc2 = false;
            reachLoc1 = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
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
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Destory());
    }
    IEnumerator SetCollision()
    {
        transform.GetChild(2).GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        transform.GetChild(2).GetComponent<Collider2D>().enabled = true;
    }
    public void collision()
    {
        StartCoroutine(SetCollision());
    }
    IEnumerator Destory()
    {
        transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            speed = -speed;
        }
       



    }
    private void Attack()
    {
        CreateBullet();
    }
    void CreateBullet()
    {
        Vector3 BulletPosition = new Vector3();
        Vector2 BulletDirection = new Vector2();
        float BulletSpeed = 5f;

        BulletPosition = spawnbullet.transform.position;







        var NewBullet = Instantiate(bullet, BulletPosition, Quaternion.identity, null);
        var NewBulletRigidbody = NewBullet.GetComponent<Rigidbody2D>();
       
        if (transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
        {
            BulletDirection = new Vector2(-1, -0.1f);
        }
        else
        {
            BulletDirection = new Vector2(1, -0.1f);
        }
   

        NewBulletRigidbody.velocity = BulletDirection * BulletSpeed;


    }
}
