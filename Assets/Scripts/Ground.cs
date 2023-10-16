using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Move
{
    protected void FixedUpdate()
    {
        move();
        reset();
    }
}
