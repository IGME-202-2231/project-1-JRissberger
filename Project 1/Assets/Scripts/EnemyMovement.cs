using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;

    Vector3 objectPosition;

    [SerializeField]
    GameObject enemy1;

    [SerializeField]
    GameObject player;

    float minRectY;

    float maxRectY;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition.x -= (speed * Time.deltaTime);
        transform.position = objectPosition;

        //Destroys if it goes off screen
        if (objectPosition.x < -10)
        {
            //TODO: remove from list on movement script
            Destroy(enemy1);
        }

        //updates collision boundaries
        minRectY = transform.position.y + 1/2;
        maxRectY = transform.position.y + 1/2;

        Debug.Log(minRectY);
        Debug.Log(maxRectY);
        Debug.Log(player.transform.position.y);
        playerCollision();
    }

    //TODO: this isn't working. move to different script?
    void playerCollision()
    {
        if (player.transform.position.y > minRectY && player.transform.position.y < maxRectY && player.transform.position.x == objectPosition.x)
        {
            Destroy(player);
        }
    }
}
