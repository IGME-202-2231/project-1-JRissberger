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
        if (player.bullets.Count > 0)
        {
            BulletEnemyCollision();
        }
    }

    void BulletEnemyCollision()
    {
        for (int i = player.bullets.Count - 1; i >= 0; i--)
        {
            //Checks to ensure bullet hasn't already been removed
            if (player.bullets[i] != null)
            {
                for (int ii = enemies.Count - 1; ii >= 0; ii--)
                {
                    //Another check to make sure the bullet still exists
                    if (player.bullets[i] != null &&
                    player.bullets[i].transform.position.x <= enemies[ii].maxRectX &&
                    player.bullets[i].transform.position.x >= enemies[ii].minRectX &&
                    player.bullets[i].transform.position.y >= enemies[ii].minRectY &&
                    player.bullets[i].transform.position.y <= enemies[ii].maxRectY)
                    {
                        enemies[ii].IsColliding = true;
                        Destroy(player.bullets[i]);
                        player.bullets[i] = null;
                    }
                }
            }
        }
    }
}
