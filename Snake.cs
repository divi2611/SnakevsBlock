using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent( typeof(TailGenerator))]
[RequireComponent( typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead head;
    [SerializeField] private float speed;
    [SerializeField] private float tailSprengness;
    
    

    private SnakeInput _input;
    private List<Segment> _tail;
    private TailGenerator _tailGenerator;

    public event UnityAction<int> SizeUpdated;
    

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _input = GetComponent<SnakeInput>();
        _tail = _tailGenerator.Generate();
        
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        head.Blockcollied += OnBlockCollied;
    }

    private void OnDisable()
    {
        head.Blockcollied -= OnBlockCollied;
    }

    private void FixedUpdate()
    {
        Move(head.transform.position + head.transform.up * speed * Time.fixedDeltaTime);
        head.transform.up = _input.GetDirectionToClick(head.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = head.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition,
                tailSprengness * Time.deltaTime);
            previousPosition = tempPosition;
        }
        
        head.Move(nextPosition);
    }


    private void OnBlockCollied()
    {
        Segment deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);
        SizeUpdated?.Invoke(_tail.Count);
        
        
    }
    
}
