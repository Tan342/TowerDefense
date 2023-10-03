using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Maxhp = 5;
    int currentHp = 0;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = Maxhp;
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "WeaponBullet")
        {
            currentHp--;
            if(currentHp == 0)
            {
                bank.Deposit(25);
                Destroy(gameObject);
            }
        }
    }
}
