using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OctopusPatrol : MonoBehaviour
{

    public Transform groundPos;
    public float speed;
    public float radius;
    public LayerMask groundLayer;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        rb.velocity = new Vector2(speed, 0f);

        bool isGrounded = Physics2D.OverlapCircle(groundPos.position, radius, groundLayer);

        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ninja")
        {
            SceneManager.LoadScene(0);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
