using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float range = 5f;
    [SerializeField] ParticleSystem arrow;

    Vector3 closestWeapon = new Vector3();
    float minDistance = Mathf.Infinity;
    EnemyMover enemyMover;

    // Start is called before the first frame update
    void Start()
    {
        enemyMover = GetComponent<EnemyMover>();
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        Aim();
    }

    void FindClosestTarget()
    {
        Weapon[] weapon = FindObjectsOfType<Weapon>();
        minDistance = Mathf.Infinity;
        
        foreach(Weapon e in weapon)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestWeapon = e.transform.position;
            }
        }
    }

    void Aim()
    {
        var emission = arrow.emission;
        if(minDistance > range)
        {
            emission.enabled = false;
            enemyMover.Move();
            return;
        }

        transform.LookAt(closestWeapon);
        emission.enabled = true;
        enemyMover.StopMove();
        
    }
}
