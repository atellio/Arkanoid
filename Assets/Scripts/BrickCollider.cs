using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollider : AkCollider
{
    private Brick brick;


    private void Awake()
    {
        brick = GetComponent<Brick>();
    }

    public override void OnCollision()
    {
        brick.OnHit();
    }
}
