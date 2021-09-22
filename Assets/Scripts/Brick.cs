using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Health = 3;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Health--;

            if(Health <= 0)
            {
                DoDeath();
            }
            else
            {
                DoDamageAnimation();
            }
        }
    }

    private void DoDeath()
    {
        Powerup powerup = PowerupManager.Instance.GetPowerup();
        powerup.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void DoDamageAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(DamageAnimation());
    }

    private IEnumerator DamageAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        switch(Health)
        {
            case 2:
                spriteRenderer.color = Color.yellow;
                break;
            case 1:
                spriteRenderer.color = Color.magenta;
                break;
        }
    }
}
