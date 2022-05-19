using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TailGenerator : MonoBehaviour
{
    [SerializeField] private int tailsize;
    [SerializeField] private Segment segmentTempate;

    public List<Segment> Generate()
    {
        List<Segment> tail = new List<Segment>();
        
        for (int i = 0; i < tailsize; i++)
        {
            tail.Add(Instantiate(segmentTempate, transform));
        }

        return tail;
        
    }
}
