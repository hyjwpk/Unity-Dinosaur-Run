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
        int multiply = Mathf.Min(1 + (Point.getPoint() / 5000), 2);
        for (int i = 0; i < activeElements.Count; i++)
        {
            activeElements[i].transform.position -= Vector3.right * scrollSpeed * multiply * Time.deltaTime;
        }
    }

    public void GenerateObstacles()
    {
        if (activeElements.Count == Obstacles.Count) return;
        int n = Random.Range(0, Obstacles.Count);
        GameObject go = Obstacles[n];
        if (!activeElements.Contains(go))
            activeElements.Add(go);
        else GenerateObstacles();
    }

    public void ResetObstaclesAll()
    {
        foreach (GameObject target in activeElements)
        {
            int operate = Random.Range(0, 20);
            target.transform.position = new Vector3(38 + operate, -11, 1);
        }
        activeElements.Clear();
    }

    public void ResetObstacles(GameObject target)
    {
        int operate = Random.Range(0, 20);
        target.transform.position = new Vector3(38 + operate, -11, 1);
        activeElements.Remove(target);
    }
}
