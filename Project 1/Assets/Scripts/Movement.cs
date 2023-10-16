using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //initial position
    Vector2 objectPosition = Vector2.zero;

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject enemy1;

    [SerializeField]
    GameObject player;

    bool isColliding = false;

    //List of current bullets
    List<GameObject> bullets = new List<GameObject> ();

    //List of current enemies
    List<GameObject> enemies = new List<GameObject> ();

    //List of enemies' min/max Y collision values
    //TODO: find a better way to store this. for now, x is min and y is max.
    //Maybe nesting things?? but right now I just want this to work tbh
    //List<Vector2> enemyMinMax = new List<Vector2> ();

    //Timer for enemy spawning
    float spawnTimer = 0f;

    void Start()
    {
        //Checks initial object position so player isn't automatically centered at start
        objectPosition = transform.position;
    }

    void Update()
    {
        //up
        if(Input.GetKey(KeyCode.W))
        {
            objectPosition.y += (speed * Time.deltaTime);

            //oob top
            if (objectPosition.y > 5)
            {
                objectPosition.y = 5;
            }
        }
        //down
        if(Input.GetKey(KeyCode.S))
        {
            objectPosition.y -= (speed * Time.deltaTime);

            //oob bottom
            if (objectPosition.y < -5)
            {
                objectPosition.y = -5;
            }
        }
        //left
        if(Input.GetKey(KeyCode.A))
        {
            objectPosition.x -= (speed * Time.deltaTime);

            //oob left
            if (objectPosition.x < (float)-8.5)
            {
                objectPosition.x = (float)-8.5;
            }
        }
        //right
        if(Input.GetKey(KeyCode.D))
        {
            objectPosition.x += (speed * Time.deltaTime);
            //oob right
            if (objectPosition.x > -6)
            {
                objectPosition.x = -6;
            }
        }

        //Fire
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Adds bullet to list
            bullets.Add(Instantiate(bullet, new Vector3(objectPosition.x, objectPosition.y, 0), Quaternion.identity));           
        }

        //Applies validated position
        transform.position = objectPosition;

        //Decreases timer
        spawnTimer -= Time.deltaTime;

        //Spawns when timer reaches zero, then resets timer
        if (spawnTimer <= 0)
        {
            float y = Random.Range(-4, 4);
            enemies.Add(Instantiate(enemy1, new Vector3(7, y, 0), Quaternion.identity));
            spawnTimer = 5;
            //enemyMinMax[enemies.Count - 1].x = y - 1 / 2;
            //enemyMinMax[enemies.Count - 1].y = y + 1 / 2;
        }

        if (isColliding)
        {
            Destroy(player);
        }
    }

    //nested loops to check for collision 
    //Mostly placeholder stuff right now
    /*void bulletEnemyCollision()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            for (int ii = bullets.Count - 1; ii >= 0; ii--)
            {
                if (bullets[ii].x < enemyMinMax[i].y && bullets[ii].x > enemyMinMax[i].x && bullets[ii].y == )              
                    Destroy(bullets[ii]);
                    bullets[ii] = null;

                    Destroy(enemies[i]);
                    enemies[i] = null;
                }
            }
        }
    } */

}

