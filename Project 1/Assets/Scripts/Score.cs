using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    Movement player;

    [SerializeField]
    TextMesh score;

    // Update is called once per frame
    void Update()
    {
        //updates text to reflect current score
        score.text = "Score: " + player.TotalScore;
    }
}
