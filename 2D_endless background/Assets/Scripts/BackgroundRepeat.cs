using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        groundHorizontalLength = bc2d.size.x * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground() 
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
