using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Move
{
    [SerializeField] protected float distanceForDestroy;
    protected void FixedUpdate()
    {
        move();
    }

    public virtual void turnOffCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    protected virtual void destroy()
    {
        if (gameObject.transform.position.x < -distanceForDestroy) Destroy(gameObject);
    }

}