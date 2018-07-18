using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep_control : MonoBehaviour {

    float speed = 5f;
    float upfactor = 500;
    Vector2 dir = Vector2.left;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        dir = new Vector2(-1 * dir.x, dir.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="miku_run")
        {
            if(collision.contacts[0].point.y>transform.position.y)
            {
                GetComponent<Animator>().SetTrigger("dead");

                GetComponent<Collider2D>().enabled = false;

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upfactor);

                Invoke("Gameover", 4);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

    }

    void Gameover()
    {
        Destroy(gameObject);
    }
}
