using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // префаб снаряда для стрельбы
    public Transform shotPrefab;
    
    // время перезарядки
    public float shootingRate = 10.25f;

    // перезарядка
    private float shootCooldown;


    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // создаем новый выстрел
            var shotTransform = Instantiate(shotPrefab);

            // выстрел будет жить 20 сек
            Destroy(shotTransform.gameObject, 20);

            // определим положением
            shotTransform.position = transform.position;

            // свойство врага
            Shot shot = shotTransform.gameObject.GetComponent<Shot>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            Move move = shotTransform.gameObject.GetComponent<Move>();
            if (move != null)
            {
                move.direction = this.transform.right; // для двумерного пространства это будете справа от спрайта
            }
        }
    }


    /// <summary>
    /// готово ли оружие выпустить новый снаряд ?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
