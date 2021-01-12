using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public Color highlightColor = Color.cyan;


    private void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            // меняем цвет кнопки при наведении
            // на нее указателя мыши
            sprite.color = highlightColor;
        }
    }


    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }


    private void OnMouseDown()
    {
        // в мемент щелчка увеличим кнопку
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }


    private void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            // отправим сообщение целевому объекту
            // в момент щелчка на кнопке
            targetObject.SendMessage(targetMessage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
