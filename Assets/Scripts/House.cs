using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] int maxHp = 3;
    [SerializeField] int AmountPerSec = 5;
    int currentHp = 0;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        bank = FindObjectOfType<Bank>();
        StartCoroutine("MakeMoney");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeMoney()
    {
        yield return new WaitForSeconds(1f);
        bank.Deposit(AmountPerSec);
        StartCoroutine("MakeMoney");
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
