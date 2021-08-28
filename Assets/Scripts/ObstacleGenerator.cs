using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public static ObstacleGenerator Instance
    {
        get
        {
            if (myInstance == null)
                myInstance = FindObjectOfType(typeof(ObstacleGenerator)) as ObstacleGenerator;
            return myInstance;
        }
    }

    public List<GameObject> Obstacles;
    static ObstacleGenerator myInstance;
    static int instance = 0;
    List<GameObject> activeElements = new List<GameObject>();
    public float scrollSpeed = 40;

    void Start()
    {
        instance++;
        if (instance > 1) Debug.LogError("错误");
        else myInstance = this;
        GenerateObstacles();
    }

    void Update()
    {
        ScrollLevel();
    }

    void ScrollLevel()
    {
        int multiply =  Mathf.Min(1+(Point.getPoint()/5000),2);
        for (int i = 0; i < activeElements.Count; i++)
        {
            activeElements[i].transform.position -= Vector3.right * scrollSpeed *multiply* Time.deltaTime;
        }
    }

    public void GenerateObstacles()
    {
        int n = Random.Range(0, Obstacles.Count);
        GameObject go = Obstacles[n];
        activeElements.Add(go);
    }

    public void ResetObstacles()
    {
        GameObject back = activeElements[0];
        int operate= Random.Range(0,20);
        back.transform.position = new Vector3(38+operate, -11, 1);       
        activeElements.RemoveAt(0);
    }
}
