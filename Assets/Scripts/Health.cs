using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    private bool colliding;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (colliding == true)
        {
            TakeDamage(1);
        }
    }
    void OnCollisionEnter (Collision target)
    {
        
        if (target.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
        }
        if(target.gameObject.tag == "Enemy")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit(Collision target)
    {
        if(target.gameObject.tag == "Enemy")
        {
            colliding = false;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
