using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // всего хитпоинтов
    public int hp = 1;

    // враг или игрок ?
    public bool isEnemy = true;

    public void Damage(int damageCount) 
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // смерть!
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // это выстрел ?
        Shot shot = collision.gameObject.GetComponent<Shot>();
        if (shot != null)
        {
            // избегайте дружественного огня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // уничтожить выстрел
                //Destroy(shot.gameObject);
            }
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
