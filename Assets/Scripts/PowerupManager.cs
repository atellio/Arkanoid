using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance { get { return instance; } }
    private static PowerupManager instance;

    public Powerup powerupPrefab;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public Powerup GetPowerup()
    {
        return Instantiate(powerupPrefab);
    }
}
