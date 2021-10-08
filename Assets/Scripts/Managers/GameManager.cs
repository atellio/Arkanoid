using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int maxLives;
    private int currentLives;

    
    public void SetupNewGame()
    {
        currentLives = maxLives;
    }
}
