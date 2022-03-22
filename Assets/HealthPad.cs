using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPad : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


    }
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnCollisionStay(Collision target)
    {
        
            if (target.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                TakeDamage(0.1f);
           
                
            }
        
    }
}
