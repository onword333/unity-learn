using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;


    [SerializeField] private MemoryCard originCard;
    [SerializeField] private Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = originCard.transform.position;

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originCard;
                } 
                else 
                {
                    card = Instantiate(originCard) as MemoryCard;
                }

                int _id = Random.Range(0, images.Length);
                card.SetCard(_id, images[_id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }


        int id = Random.Range(0, images.Length);
        originCard.SetCard(id, images[id]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
