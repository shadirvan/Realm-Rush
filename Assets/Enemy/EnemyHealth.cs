using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // add enemy scripts everytime enemyhealth script added to new object

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Add amount to enemy max hitpoints every time enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;   
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnParticleCollision(GameObject other) 
    {
        processHit();
    }
    
    void processHit()
    {
        currentHitPoints--;
        
        if(currentHitPoints <= 0)
        {

            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
