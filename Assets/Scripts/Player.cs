using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 Velocity { get; private set; }

    private List<Ball> attachedBalls = new List<Ball>();
    private float speed = 7f;
    private const string POWERUP_TAG = "Powerup";


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Velocity = new Vector2(horizontal * speed, 0f);

        if (horizontal != 0)
        {
            transform.Translate(Velocity * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void AddBall(Ball ball)
    {
        if(!attachedBalls.Contains(ball))
        {
            attachedBalls.Add(ball);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(POWERUP_TAG))
        {
            Powerup powerup = collision.gameObject.GetComponent<Powerup>();
            if (powerup) powerup.Collect();
        }
    }

    private void Fire()
    {

    }
}
