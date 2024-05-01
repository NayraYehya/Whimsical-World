using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Vector3 pos;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;

    public int speed;
    private int count = 0;

    [SerializeField] private float health;
    [SerializeField] private float MaxHealth;
    [SerializeField] private Image HealthBar;
    [SerializeField] private TMP_Text StarCount;
    [SerializeField] private float damage;


    public UIManager uiManager;
    private bool dead;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        MaxHealth = health;
    }

    // Update is called once per frame 
    void Update()
    {
        run();
        jump();
        HealthBar.fillAmount = Mathf.Clamp(health / MaxHealth, 0 , 1);
        StarCount.text = count.ToString();

        if(health <= 0 && !dead)
        {
            dead = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            anim.SetBool("die", true);
            uiManager.GameOverFunc();
            Debug.Log("Dead");
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //rb.AddForce(new Vector2(0, speed));
                anim.SetBool("jump", true);
                rb.velocity = new Vector2(0, 10);
            }
            else
            {
                anim.SetBool("jump", true);
                rb.velocity = new Vector2(0, 5);
            }
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    void run()
    {
        
        pos = new Vector3(); //to reset key pressed
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("run", true);
            spriteRenderer.flipX = false;
            pos += transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            anim.SetBool("run" , true);
            pos -= transform.right * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("run", false);
        }
        transform.Translate(pos);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("star"))
        {
            other.gameObject.SetActive(false);
            //count += 1;
            count += 1;
            Debug.Log(count);
        }
        if (other.gameObject.CompareTag("sea"))
        {
            anim.SetBool("die", true);
            uiManager.GameOverFunc();

            Debug.Log("Dead");
        }
        if (other.gameObject.CompareTag("Win"))
        {
            uiManager.WinFunc();
        }
        if (other.gameObject.CompareTag("Out"))
        {
            uiManager.GameOverFunc();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= damage;
        }
    }
}
