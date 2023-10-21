using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //initial position
    Vector2 objectPosition = Vector2.zero;

    float speed = 4.0f;

    [SerializeField]
    GameObject bullet;

    //bool isColliding = false;

    //List of current bullets
    public List<GameObject> bullets = new List<GameObject> ();

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

        //Removes oob bullets
        BulletPositionCheck();
    }

    void BulletPositionCheck()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] != null)
            {
                if (bullets[i].transform.position.x > 10)
                {
                    Destroy(bullets[i]);
                    bullets[i] = null;
                }
            }
        }
    }
}


