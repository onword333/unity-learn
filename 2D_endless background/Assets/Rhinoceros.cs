﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhinoceros : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.collider.GetComponent<Player>() != null)
        {
            GameControll.instance.PlayerCrashed();
        }
    }
}
