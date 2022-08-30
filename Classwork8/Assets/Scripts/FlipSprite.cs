using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    bool isFacingRight = true;

    public GameObject bullet;
    GameObject bulletClone;
    public Transform leftSpawn;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && isFacingRight == false)
        {
            sprite.flipX = false;
            isFacingRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && isFacingRight == true)
        {
            sprite.flipX = true;
            isFacingRight = false;
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && isFacingRight)
        {
            bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bulletClone, 1.3f);
        }
        else if (Input.GetMouseButtonDown(0) && !isFacingRight)
        {
            bulletClone = Instantiate(bullet, leftSpawn.position, leftSpawn.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bulletClone, 1.3f);
        }
    }

    
}
