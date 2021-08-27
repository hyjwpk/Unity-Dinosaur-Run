using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEdge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ResetTrigger")
        {
            ObstacleGenerator.Instance.ResetObstacles();
            ObstacleGenerator.Instance.GenerateObstacles();
        }
    }
}
