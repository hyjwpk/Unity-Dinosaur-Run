using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _animator.SetBool("Dead", false);
            Point.point = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ResetTrigger")
        {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Dead", true);
            ObstacleGenerator.Instance.ResetObstacles();
            ObstacleGenerator.Instance.GenerateObstacles();
            Time.timeScale = 0;
        }
    }
}
