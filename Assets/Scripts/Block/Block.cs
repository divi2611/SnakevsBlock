using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField]private Vector2Int destroyPriceRange;
    
    private int _destroyPrice;
    private int _filling;

    public event UnityAction<int> FillingUpdated;
    public int LeftToFill => _destroyPrice - _filling;

    private void Start()
    {
        _destroyPrice = Random.Range(destroyPriceRange.x,destroyPriceRange.y);
        
        FillingUpdated?.Invoke(LeftToFill);
    }
  
    public void Fill()
    {
        _filling ++;
        FillingUpdated?.Invoke(LeftToFill);
        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
            
    }
}
