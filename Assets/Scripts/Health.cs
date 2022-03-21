using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float dropchance;
    [SerializeField] private GameObject medkit;
    public bool colliding;
    private Health playercollision; 
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        playercollision = g.GetComponent<Health>();
    }

    // Update is called once per frame
    void FixedUpdate() {      

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        if (colliding == true)
        {
            TakeDamage(1);
        }
        
        if (currentHealth <= 0)
        {
            float dropvalue = Random.Range(0f, 1f);
            if (1 - dropchance < dropvalue)
            {
                Instantiate(medkit, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
            }
            Destroy(gameObject);
            playercollision.colliding = false;

        }
    }
    void OnCollisionEnter (Collision target)
    {
        
        if (gameObject.tag == target.gameObject.tag && currentHealth < maxHealth)
        {
            
            AddHealth(10);
            Destroy(target.gameObject);
        }

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
    void AddHealth(int health)
    {
        currentHealth += health;

        healthBar.SetHealth(currentHealth);
    }

}
