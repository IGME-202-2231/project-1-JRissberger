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

    float lives = 3;

    [SerializeField]
    SpriteRenderer renderer;

    //Alerts that game is being reset
    bool reset;

    public bool Reset
    {
        get { return reset; }
        set { reset = value; }
    }

    //Player's current score
    float totalScore;

    public float TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    //Highest recorded score, displays at game over
    float highScore = 0;

    public float HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }

    //Checks the current state of the game
    bool gameover = false;

    public bool Gameover
    {
        get { return gameover; }
    }

    //Renderer size is multipled by half the scale increase used in Unity
    //Returns min size
    public float minRectX
    {
        get { return transform.position.x - renderer.size.x * 3f; }
    }

    public float minRectY
    {
        get { return transform.position.y - renderer.size.y * 3f; }
    }

    //Returns max size
    public float maxRectX
    {
        get { return transform.position.x + renderer.size.x * 3f; }
    }

    public float maxRectY
    {
        get { return transform.position.y + renderer.size.y * 3f; }
    }

    public float Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    public List<GameObject> Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }

    //List of current bullets
    List<GameObject> bullets = new List<GameObject> ();

    void Start()
    {
        //Checks initial object position so player isn't automatically centered at start
        objectPosition = transform.position;
    }

    void Update()
    {
        //Can only play when not in a game over state
        if (!gameover)
        {
            //up
            if (Input.GetKey(KeyCode.W))
            {
                objectPosition.y += (speed * Time.deltaTime);

                //oob top
                if (objectPosition.y > 5)
                {
                    objectPosition.y = 5;
                }
            }
            //down
            if (Input.GetKey(KeyCode.S))
            {
                objectPosition.y -= (speed * Time.deltaTime);

                //oob bottom
                if (objectPosition.y < -5)
                {
                    objectPosition.y = -5;
                }
            }
            //left
            if (Input.GetKey(KeyCode.A))
            {
                objectPosition.x -= (speed * Time.deltaTime);

                //oob left
                if (objectPosition.x < -8)
                {
                    objectPosition.x = -8;
                }
            }
            //right
            if (Input.GetKey(KeyCode.D))
            {
                objectPosition.x += (speed * Time.deltaTime);
                //oob right
                if (objectPosition.x > -5)
                {
                    objectPosition.x = -5;
                }
            }

            //Fire
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Adds bullet to list
                bullets.Add(Instantiate(bullet, new Vector3(objectPosition.x, objectPosition.y, 0), Quaternion.identity));
            }

            //Applies validated position
            transform.position = objectPosition;

            //Checking for gameover
            if (lives <= 0)
            {
                gameover = true;
            }

        }
        else
        {
            //Changes player to red
            renderer.color = Color.red;

            //Resets game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lives = 3;
                totalScore = 0;
                gameover = false;
                renderer.color = Color.white;
            }
        }
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


