using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private CircleCollider2D circleCollider;
    private Vector2 direction = new Vector2(1, 1);
    private float speed = 6f;
    private float radius = .2f;

    Vector2 colCheckPos;
    Vector2 colPos = Vector2.zero;


    private void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        radius = circleCollider.radius * transform.localScale.x;
    }

    private void Start()
    {
        direction.Normalize();
    }

    void Update()
    {
        Vector2 nextPosition = (Vector2)transform.position + (direction * speed * Time.deltaTime);
        colCheckPos = nextPosition;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            RaycastHit2D? hit;

            if (IsCollsionAtLocation(transform.position, nextPosition, out hit))
            {
                colPos = hit.Value.point;
                PerformCollision(hit);
                Bounce(hit);
            }
            else
            {
                DoMove(nextPosition);
            }
        //}
    }

    private bool IsCollsionAtLocation(Vector2 currentPosition, Vector2 nextPosition, out RaycastHit2D? hit)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, direction, speed * Time.deltaTime);

        if (hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].transform.CompareTag("Ball"))
                {
                    print("hit");
                    hit = hits[i];
                    return true;
                }
            }
        }

        hit = null;
        return false;
    }

    private void DoMove(Vector2 position)
    {
        transform.position = position;
    }

    private void PerformCollision(RaycastHit2D? hit)
    {
        AkCollider collider = hit.Value.transform.GetComponent<AkCollider>();

        if (collider != null)
        {
            collider.OnCollision();
        }
    }

    private void Bounce(RaycastHit2D? hit)
    {
        Vector2 prevDirection = direction;
        float totalTravelDistance = speed * Time.deltaTime;
        float distanceToHit = Vector3.Distance(transform.position, hit.Value.point);
        float remainingTravelAfterHit = totalTravelDistance - distanceToHit;

        print("Bounce");
        direction = Vector2.Reflect(direction, hit.Value.normal);

        //if (hit.Value.transform.CompareTag("Player"))
        //{
        //    Player player = hit.Value.transform.gameObject.GetComponent<Player>();
        //    direction += player.Velocity;
        //}

        transform.position = hit.Value.point + (hit.Value.normal * radius);
        direction.Normalize();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(colCheckPos, radius * 0.2f);

        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, colCheckPos);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(colPos, radius * 0.1f);
    }
}
