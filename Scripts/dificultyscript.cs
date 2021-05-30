using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dificultyscript : MonoBehaviour
{
    public float maxWidth;
    public float ballSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void adjustSpawnWidth(float Width)
    {
        maxWidth = Width;
  
    }
        public void adjustBallSize(float bSize)
    {
        ballSize = bSize;
    }
}
