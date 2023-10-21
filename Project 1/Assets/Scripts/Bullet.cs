using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 2.0f;

    Vector3 objectPosition;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    SpriteRenderer renderer;

    /*[SerializeField]
    List<EnemyMovement> enemies = new List<EnemyMovement> (); */

    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;

        //Finds enemies and adds to gameobject list
        //TODO: why are these null?
        /*enemies.Add(GameObject.Find("Type1").GetComponent<EnemyMovement>());
        enemies.Add(GameObject.Find("Type1.2").GetComponent<EnemyMovement>());
        enemies.Add(GameObject.Find("Type1.3").GetComponent<EnemyMovement>());
        enemies.Add(GameObject.Find("Type1.4").GetComponent<EnemyMovement>()); */

        
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition.x += (speed * Time.deltaTime);
        transform.position = objectPosition;

        //Destroys if it goes off screen
        if (objectPosition.x > 10)
        {
            //TODO: how to remove from list? may need to destroy from list
            Destroy(bullet);
        }
    }

    //Checks if bullet has collided with enemy. Only checks using center of bullet due to size. 
    /*public void CollisionCheck()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (transform.position.x > enemies[i].minRectX &&
                transform.position.x < enemies[i].maxRectX &&
                transform.position.y > enemies[i].minRectY &&
                transform.position.y < enemies[i].maxRectY)
            {
                enemies[i].IsColliding = true;
            }
        }
    } */
}
