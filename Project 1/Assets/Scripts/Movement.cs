using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //initial position
    Vector3 objectPosition = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

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
            if (objectPosition.x < (float)-9.5)
            {
                objectPosition.x = (float)-9.5;
            }
        }
        //right
        if(Input.GetKey(KeyCode.D))
        {
            objectPosition.x += (speed * Time.deltaTime);
            //oob right
            if (objectPosition.x > -7)
            {
                objectPosition.x = -7;
            }
        }

        //Applies validated position
        transform.position = objectPosition;
    }
}

