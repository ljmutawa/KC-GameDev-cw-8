using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
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
}
