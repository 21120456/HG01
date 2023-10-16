using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bird : MonoBehaviour
{
    private static Bird instance;
    public static Bird Instance { get { return instance; } }

    [SerializeField] protected float jumpForce;
    [SerializeField] protected float jumpDelay0;
    [SerializeField] protected float jumpDelay1;
    [SerializeField] protected float jumpTimer;
    [SerializeField] protected float playingSoundDelay;
    [SerializeField] protected float playingSoundTimer;
    [SerializeField] protected float gravity;

    [SerializeField] protected AudioSource soundJump;
    [SerializeField] protected AudioSource soundGetPoint;
    [SerializeField] protected AudioSource soundHit;
    [SerializeField] protected AudioSource soundDead;

    [SerializeField] protected bool isPlayingSound;

    [SerializeField] protected bool isDead;
    public bool IsDead { get { return isDead; } }

    [SerializeField] protected bool isStart;
    public bool IsStart { get { return isStart; } }

    [SerializeField] protected int point;
    public int Point { get { return point; } }

    [SerializeField] protected int highPoint;
    public int HighPoint { get { return highPoint; } }

    [SerializeField] protected Rigidbody2D rb;


    protected void Awake()
    {
        Bird.instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updatePoint(int point)
    {
        if (point > this.point) highPoint = point;
    }

    protected void FixedUpdate()
    {
        if (!isDead)
        {
            jump();
            rotate();
        }
    }

    public virtual void updateTime()
    {
        playingSoundTimer = playingSoundDelay;
    }

    protected virtual void jump()
    {
        bool jump = InputManager.Instance.IsJump;
        if (!jump)
        {
            //jumpTimer = 0;
            return;
        }
        rb.gravityScale = gravity;
        isStart = true;
        if (jump)
        {
            this.jumpTimer += Time.fixedDeltaTime;
            this.playingSoundTimer += Time.fixedDeltaTime;
            if (jumpTimer < jumpDelay0)
            {
                rb.velocity = new Vector2(0, jumpForce);
                if (playingSoundTimer > playingSoundDelay)
                {
                    soundJump.Play();
                    playingSoundTimer = 0;
                }

            }
            if (jumpTimer<jumpDelay0 && jumpTimer < jumpDelay1) return;
            jumpTimer = 0;
        }
    }

    protected virtual void rotate()
    {
        if (rb.velocity.y>=0)
        {
            Quaternion quaternion = new Quaternion(0, 0, (rb.velocity.y / jumpForce) / 3, 1);
            gameObject.transform.rotation = quaternion;
        }
        else
        {
            float velocityY;
            if (rb.velocity.y < -jumpForce) velocityY = jumpForce;
            else velocityY = rb.velocity.y;
            Quaternion quaternion = new Quaternion(0, 0, (rb.velocity.y / jumpForce) / 3, 1);
            gameObject.transform.rotation = quaternion;
        }
        
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!isDead)
            {
                soundHit.Play();
                soundDead.Play();
                isDead = true;
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            if (!isDead)
            {
                soundHit.Play();
                soundDead.Play();
                isDead = true;
            }
        }
        if (collision.gameObject.tag == "GetPoint")
        {
            point += 1;
            if (point > highPoint) highPoint = point;
            collision.gameObject.GetComponent<Pipe>().turnOffCollider();
            soundGetPoint.Play();
        }
    }
}
