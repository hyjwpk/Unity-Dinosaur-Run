using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
     private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
          _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("Dead", false);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name=="ResetTrigger"){ 
          _animator.SetBool("Jump", false);
          _animator.SetBool("Dead", true);
        }
    }
}
