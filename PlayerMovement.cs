using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OK
{
    public class PlayerMovement : MonoBehaviour
    {
        private GravityToggle gravity;
        private Rigidbody2D rb;
        private BoxCollider2D coll;
        private Animator anim;
        private SpriteRenderer sprite;

        [SerializeField] private LayerMask jumpableGround;

        private float dirX = 0f;
        public float moveSpeed = 7f;
        public float jumpForce = 10f;
        
        private enum MovementState {idle, running, jumping, falling}

        [SerializeField] private AudioSource jumpEffect;
    
        void Start()
        {
            gravity = GetComponent<GravityToggle>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            coll = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpEffect.Play();
            }

            if (Input.GetButtonDown("Jump") && gravity.OnCeil())
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
                jumpEffect.Play();
            }

            HandleAnimations();
        }

        private void HandleAnimations()
        {
            MovementState state;

            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if (rb.velocity.y > 0.1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -0.1f)
            {
                state = MovementState.falling;
            }

            anim.SetInteger("state", (int)state);
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        }
    }
}