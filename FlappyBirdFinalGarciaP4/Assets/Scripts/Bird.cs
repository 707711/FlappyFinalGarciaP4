using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;     //Upward force of the "flap"
    private bool isDead = false;  //had the player collided with a wall?

    private Animator anim;  //reference to the animator component
    private Rigidbody2D rb2d;  //Holds a reference to the Rigidbody2D component of the bird

    private AudioSource flapSoundEffect;

    // Start is called before the first frame update
    void Start()

    {
        //Get reference to the Animator component attached to this Game object
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow control if the bird has died
        if (isDead == false)
        {
            //Look fopr input to trigger a "flap"
            if (Input.GetMouseButtonDown(0))
            {
                //...tell the animator about it then...
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before
                rb2d.velocity = Vector2.zero;
                // New vector2(rb2d.velocity.x,0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead
        isDead = true;
        //... tell the animator about it...
        anim.SetTrigger("Die");
        //... and tell the game control about it.
        GameControl.instance.BirdDied();
    }
}
