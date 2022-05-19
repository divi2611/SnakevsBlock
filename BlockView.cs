using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text view;
    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
        
    }
    
    private void OnEnable()
    {
        _block.FillingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        _block.FillingUpdated -= OnFillingUpdated;
        
    }

    private void OnFillingUpdated(int leftToFill)
    {
        view.text = leftToFill.ToString();
    }
    
}
