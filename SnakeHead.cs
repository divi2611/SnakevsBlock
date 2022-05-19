using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public event UnityAction Blockcollied;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector3 newPosition)
    {
        _rigidbody2D.MovePosition(newPosition);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            
            { 
                Blockcollied?.Invoke();
                //Debug.Log("This is Block");
                block.Fill();
            }
           
        }
    }
}
   

