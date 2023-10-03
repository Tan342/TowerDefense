using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float range = 5f;
    [SerializeField] ParticleSystem arrow;

    Vector3 closestEnemy = new Vector3();
    float minDistance = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        Aim();
    }

    void FindClosestTarget()
    {
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        minDistance = Mathf.Infinity;
        
        foreach(Enemy e in enemy)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = e.transform.position;
            }
        }
    }

    void Aim()
    {
        var emission = arrow.emission;
        if(minDistance > range)
        {
            emission.enabled = false;
            return;
        }

        transform.LookAt(closestEnemy);
        emission.enabled = true;
    }

    
}
