using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    private Vector3 direction;
    private Vector3 touchPosition;
    private bool isLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            Vector2 movement = new Vector2(direction.x, direction.y);
            rb2d.velocity = movement * speed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb2d.velocity = Vector2.zero;
            }
        }         

    }   
}
