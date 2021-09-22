﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 2f;


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
