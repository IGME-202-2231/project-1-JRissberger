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

    [SerializeField]
    SpriteRenderer renderer;

    bool isColliding = false;

    public bool IsColliding
    {
        get { return isColliding ; }
        set { isColliding = value; }
    }
    //Returns min size
    public float minRectX
    {
        get { return transform.position.x - renderer.size.x / 2; }
    }

    public float minRectY
    {
        get { return transform.position.y - renderer.size.y / 2; }
    }

    //Returns max size
    public float maxRectX
    {
        get { return transform.position.x + renderer.size.x / 2; }
    }

    public float maxRectY
    {
        get { return transform.position.y + renderer.size.y / 2; }
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition.x -= (speed * Time.deltaTime);

        //Resets position at a random x and y axis off screen
        if (objectPosition.x < -10 || isColliding)
        {
            objectPosition.x = Random.Range(10, 15);
            objectPosition.y = Random.Range(-4, 4);

            if (isColliding)
            {
                //isColliding = false;
                renderer.color = Color.red;
            }
        }

        //Applies position
        transform.position = objectPosition;
      
    }
}
