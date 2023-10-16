using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : Move
{
    protected void FixedUpdate()
    {
        move();
        reset();
    }
}
