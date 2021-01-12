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

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    public bool canReveal 
    {
        get { return _secondRevealed == null; } // если вторая карта уже открыта, то false
    }

    public void CardRevealed(MemoryCard card) 
    { 
    
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = originCard.transform.position;

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
        numbers = ShuffleArray(numbers);

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

                int index = j * gridCols + i;

                int _id = numbers[index];
                card.SetCard(_id, images[_id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }


        int id = Random.Range(0, images.Length);
        originCard.SetCard(id, images[id]);
    }

    private int[] ShuffleArray(int[] numbers) 
    {
        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
