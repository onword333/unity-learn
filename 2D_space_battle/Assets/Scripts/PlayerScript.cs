using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Rigidbody2D rb;

    // направление движения
    private Vector2 movement;
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        // 5 - стрельба
        bool shoot = Input.GetButtonDown("Fire1");

        if (shoot)
        {
            if (weapon != null)
            {
                // ложь, т.к. игрок не враг
                weapon.Attack(false);
            }
        }
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        movement = new Vector2(inputX, inputY);
        rb.velocity = movement * speed;
    }
}
