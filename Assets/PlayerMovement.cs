using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed;
    public float walkspeed;
    public float runspeed;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool dead;
    public GameObject Bullet;
    public GameObject SpawnBulletPosition;
    public TMP_Text healthText;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text coinText;
    private int lives = 3;
    private float leftTime = 60;
    private float leftTime1 = 60 ;
    public bool canShoot;
    private int score = 0;
    private int coins = 0;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftTime1 == 0)
        {
            StartCoroutine(Respawn());
            leftTime = 5;
            
        }
       leftTime -= Time.deltaTime;
        leftTime1 = (int)leftTime;
        timeText.text = leftTime1.ToString();
        healthText.text = lives.ToString();
        scoreText.text = score.ToString();
        coinText.text = coins.ToString();
        if (lives <= 0)
        {
            lives = 0;
        }
        if (Input.GetButtonDown("Fire1")&&canShoot){

            PlayerAttack();
        }
        if (dead)
        {
            transform.position = GameObject.FindGameObjectsWithTag("Spawn")[0].transform.position;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal > 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (!IsGrounded())
        {
            speed = walkspeed;
        }
        else
        {
            speed = runspeed;
        }
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Kill")
        {
            print(col);
            col.transform.parent.GetComponent<EnemyMovement>().Kill();
        }
        if (col.tag == "Enemy")
        {


            StartCoroutine(Respawn());
        }
        if (col.tag == "Coin")
        {
            coins++;
            score += 100;
            Destroy(col.gameObject);
        }
    }
    private void PlayerAttack()
    {
        CreateBullet();
    }
    void CreateBullet()
    {
        Vector3 BulletPosition = new Vector3();
        Vector2 BulletDirection = new Vector2();
        float BulletSpeed = 5f;

        BulletPosition = SpawnBulletPosition.gameObject.transform.position;
            
       
       
     
        
         
        
        var NewBullet = Instantiate(Bullet, BulletPosition, Quaternion.identity, null);
        var NewBulletRigidbody = NewBullet.GetComponent<Rigidbody2D>();
        if(horizontal == 0)
        {
            BulletDirection = new Vector2(1, 0.5f);
        }
        else if(horizontal > 0)
        {
            BulletDirection = new Vector2(1, 0.5f);
        }
        else
        {
            BulletDirection = new Vector2(-1, 0.5f);
        }

        NewBulletRigidbody.velocity = BulletDirection * BulletSpeed;
        
        
    }
    IEnumerator Respawn()
    {
        lives--;
        dead = true;
        yield return new WaitForSeconds(0.5f);
        dead = false;
    }


}
