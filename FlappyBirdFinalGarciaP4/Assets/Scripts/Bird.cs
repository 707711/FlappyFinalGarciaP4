using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()

    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButton(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true; 
    }
}
