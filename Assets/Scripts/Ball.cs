using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 velocity = new Vector2(1, 1);
    private float speed = 12f;


    private void Start()
    {
        velocity.Normalize();
    }

    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            velocity += player.Velocity;
        }

        velocity.Normalize();
    }
}
