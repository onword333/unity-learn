using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhinoceros : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.collider.GetComponent<Player>() != null)
        {
            GameControll.instance.PlayerCrashed();
        }
    }
}
