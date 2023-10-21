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


    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition.x += (speed * Time.deltaTime);
        transform.position = objectPosition;
    }
}
