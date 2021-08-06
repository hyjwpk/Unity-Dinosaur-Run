using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpVelocity = 20f;
    public float gravityScale = 5f;
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplier = 2f;

    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    private bool jump = false;
    private bool grouded = false;
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;
    }

    void FixedUpdate()
    {
        if (jump && grouded)
        {
            _rigidBody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jump = grouded = false;
            _animator.SetBool("Jump", true);
        }
        if (_rigidBody2D.velocity.y < 0) _rigidBody2D.gravityScale = gravityScale * fallmultiplier;
        else if (_rigidBody2D.velocity.y > 0)
        {
            _rigidBody2D.gravityScale = gravityScale;
            if (!Input.GetButton("Jump")) _rigidBody2D.gravityScale *= lowjumpmultiplier;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "GroundCollider")
        {
            grouded = true;
            _animator.SetBool("Jump", false);
        }
    }
}
