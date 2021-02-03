using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.GetComponent<Rhinoceros>() != null) {
            GameControll.instance.addPoints();
        }
    }
}
