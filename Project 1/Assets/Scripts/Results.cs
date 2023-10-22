using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField]
    Movement player;

    [SerializeField]
    TextMesh results;

    // Update is called once per frame
    void Update()
    {
        if (!player.Gameover)
        {
            results.text = "";
        }
        else
        {
            results.text = "Game Over!" +
                "\nYour score: " + player.TotalScore +
                "\nHigh score: " + player.HighScore +
                "\nPress SPACE to play again!";
        }
    }
}
