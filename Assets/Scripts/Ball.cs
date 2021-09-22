using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private CircleCollider2D circleCollider;
    private Vector2 velocity = new Vector2(0, 1);
    private float speed = 6f;
    private float radius = .2f;

    Vector2 colCheckPos;


    private void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        radius = circleCollider.radius * transform.localScale.x;
    }

    private void Start()
    {
        velocity.Normalize();
    }

    void Update()
    {
        if(!DoCollisionCheck())
        {
            DoMove();
        }
    }

    private bool DoCollisionCheck()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, velocity, speed * Time.deltaTime);
        colCheckPos = (Vector2)transform.position + (velocity * speed * Time.deltaTime);
        if (hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].transform.CompareTag("Ball"))
                {
                    print("hit");
                    Bounce(hits[i]);
                    return true;
                }
            }
        }

        return false;
    }

    private void DoMove()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void Bounce(RaycastHit2D hit)
    {
        float totalTravelDistance = speed * Time.deltaTime;
        float distanceToHit = Vector3.Distance(transform.position, hit.point);
        float remainingTravelAfterHit = totalTravelDistance - distanceToHit;

        //transform.Translate(velocity * distanceToHit);

        print("Bounce");
        velocity = Vector2.Reflect(velocity, hit.normal);

        if (hit.transform.CompareTag("Player"))
        {
            Player player = hit.transform.gameObject.GetComponent<Player>();
            velocity += player.Velocity;
        }

        velocity.Normalize();
        //transform.Translate(velocity * remainingTravelAfterHit);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(colCheckPos, radius);
    }
}
