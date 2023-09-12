using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;     // Player's score
    public int lives = 3;     // Player's lives


    // Start is called before the first frame update
    void Start()
    {

        // Display initial values
        Debug.Log("Player’s Lives = " + lives);
        Debug.Log("Score = " + score);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the player feeds an animal
    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score = " + score);
    }

    // Called when the player misses an animal or is hit by one
    public void DecreaseLives()
    {
        lives--;
        Debug.Log("Player’s Lives = " + lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            // Optionally: End the game or restart the level
        }
    }
}
