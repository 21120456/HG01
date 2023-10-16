using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float distanceForReset = 10;
    [SerializeField] protected bool isDead;

    [SerializeField] protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed();
    }

    protected virtual void updateSpeed()
    {
        int point = Bird.Instance.Point;
        speed += point / 5;
    }

    protected virtual void move()
    {
        isDead = Bird.Instance.IsDead;
        if (isDead) 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    protected virtual void reset()
    {
        if (gameObject.transform.position.x < -distanceForReset) 
            gameObject.transform.position = new Vector3(distanceForReset, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
