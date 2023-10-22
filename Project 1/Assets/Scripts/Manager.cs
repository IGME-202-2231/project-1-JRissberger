using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //Accesses player data
    [SerializeField]
    Movement player;

    [SerializeField]
    List<EnemyMovement> enemies = new List<EnemyMovement> ();

    // Update is called once per frame
    void Update()
    {
        if (!player.Gameover)
        {
            if (player.Bullets.Count > 0)
            {
                BulletEnemyCollision();
            }

            PlayerEnemyCollision();
        }
    }
    
    void BulletEnemyCollision()
    {
        for (int i = player.Bullets.Count - 1; i >= 0; i--)
        {
            //Checks to ensure bullet hasn't already been removed
            if (player.Bullets[i] != null)
            {
                for (int ii = enemies.Count - 1; ii >= 0; ii--)
                {
                    //Another check to make sure the bullet still exists
                    if (player.Bullets[i] != null &&
                    player.Bullets[i].transform.position.x <= enemies[ii].maxRectX &&
                    player.Bullets[i].transform.position.x >= enemies[ii].minRectX &&
                    player.Bullets[i].transform.position.y >= enemies[ii].minRectY &&
                    player.Bullets[i].transform.position.y <= enemies[ii].maxRectY)
                    {
                        enemies[ii].IsColliding = true;
                        Destroy(player.Bullets[i]);
                        player.Bullets[i] = null;

                        //Awards points to player
                        player.TotalScore += enemies[ii].Points;

                        //Updates high score if necessary
                        if (player.TotalScore >= player.HighScore)
                        {
                            player.HighScore = player.TotalScore;
                        }
                    }
                }
            }
        }
    }

    void PlayerEnemyCollision()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (player.minRectX <= enemies[i].maxRectX &&
                player.maxRectX >= enemies[i].minRectX &&
                player.minRectY <= enemies[i].maxRectY &&
                player.maxRectY >= enemies[i].minRectY)
            {
                enemies[i].IsColliding = true;
                player.Lives -= 1;
            }
        }
    }
}
