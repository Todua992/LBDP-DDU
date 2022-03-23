using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float dropchance;
    [SerializeField] private GameObject medkit;

    public float currentHealth;
    public bool destroyed = false;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0) {
            float dropvalue = Random.Range(0f, 1f);
            if (1 - dropchance < dropvalue) {
                Instantiate(medkit, new Vector3(transform.position.x, transform.position.y + 1.7f, transform.position.z), transform.rotation);
            }

            destroyed = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision target) {
        if (target.gameObject.CompareTag("Bullet")) {
            TakeDamage(20);
        }

        if (target.gameObject.CompareTag("Player")) {
            TakeDamage(0.1f);
        }
    }

    void TakeDamage(float damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void AddHealth(float health) {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionStay(Collision target) {
        if (target.gameObject.CompareTag("Enemy")) {
            TakeDamage(1);
        }

        if (target.gameObject.CompareTag(gameObject.tag) && currentHealth + 1 < maxHealth) {
            if (target.collider.gameObject.layer == LayerMask.NameToLayer("Medkit")) {
                AddHealth(10);
                Destroy(target.gameObject);
            } else {
                AddHealth(0.1f);
            }
        }
    }
}