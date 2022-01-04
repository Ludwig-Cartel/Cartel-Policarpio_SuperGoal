using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private float dirX;


    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 7f;
     
    private enum MovementState {idle, run,fall,jump};

    [SerializeField] private AudioSource jumpSFX;


    // Start is called before the first frame update
   private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * speed, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && Grounded()) {
            jumpSFX.Play();
          rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
        }

        animationUpdate();

    }

    private void animationUpdate() {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > .1f) {

            state = MovementState.jump;
        } else if (rigidBody.velocity.y < -.1f) {
            state = MovementState.fall;
        }

        animator.SetInteger("state",(int)state);
    }

    private bool Grounded() {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}


