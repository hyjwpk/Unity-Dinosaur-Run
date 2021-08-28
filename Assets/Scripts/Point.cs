using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
  
    public static int point = 0;
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = point.ToString();
    }

    void FixedUpdate()
    {
        point += 1;
    }
     
     public static int getPoint(){
         return point;
     }
}
