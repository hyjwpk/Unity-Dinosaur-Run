using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdge : MonoBehaviour
{
    void Start () {
 
     }
 
     // Update is called once per frame
    void Update () {
 
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.name=="ResetTrigger"){ 
            print("OnTriggerEnter");
            ObstacleGenerator.Instance.ResetObstacles(); 
            ObstacleGenerator.Instance.GenerateObstacles();
        }
    }
}
