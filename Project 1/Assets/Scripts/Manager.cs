using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //Accesses player data
    [SerializeField]
    Movement player;

    //List of enemies
    //TODO: Move this over to player and randomly generate enemies??
    [SerializeField]
    List<EnemyMovement> enemies = new List<EnemyMovement> ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.bullets[0].transform.position.y);
        Debug.Log(enemies[0].minRectY);
    }

    void BulletEnemyCollision()
    {
        for (int i = player.bullets.Count; i >= 0; i--)
        {
            for (int ii = enemies.Count - 1; ii >= 0; ii--)
            {
                //TODO: check this. 
                if (player.bullets[i].transform.position.x < enemies[ii].maxRectX
                    && player.bullets[i].transform.position.x > enemies[ii].minRectX
                    && player.bullets[i].transform.position.y < enemies[ii].maxRectY &&
                    player.bullets[i].transform.position.y > enemies[ii].minRectY)

                {
                    /*enemies[ii].IsColliding = true;
                    Destroy(player.bullets[i].gameObject);
                    player.bullets[i] = null; */
                    
                }
            }
        }
    }
}
