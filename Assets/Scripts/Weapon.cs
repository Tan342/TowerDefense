using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int Maxhp = 5;
    int currentHp = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = Maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "EnemyBullet")
        {
            currentHp--;
            if (currentHp <= 0)
            {
                GridManager gridManager = FindObjectOfType<GridManager>();
                gridManager.SetPlaceable(transform.position, true);
                Destroy(gameObject);
            }
        }
    }
}
