using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 Velocity { get; private set; }
    private float speed = 7f;


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Velocity = new Vector2(horizontal * speed, 0f);

        if (horizontal != 0)
        {
            transform.Translate(Velocity * Time.deltaTime);
        }
    }
}
