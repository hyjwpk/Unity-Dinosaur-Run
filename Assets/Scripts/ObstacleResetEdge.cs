using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleResetEdge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ResetTrigger")
        {
            ObstacleGenerator.Instance.ResetObstacles();
        }
    }
}
