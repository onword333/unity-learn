using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhinoceros : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.collider.GetComponent<Player>() != null)
        {
            GameControll.instance.PlayerCrashed();
            animator.SetBool("isCrashed", true);
        }
    }
}
