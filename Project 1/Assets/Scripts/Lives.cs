using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField]
    Movement player;

    [SerializeField]
    TextMesh lives;

    // Update is called once per frame
    void Update()
    {
        //Shows current lives
        lives.text = "Lives: " + player.Lives;
    }
}
