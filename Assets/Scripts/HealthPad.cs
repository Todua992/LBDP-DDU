using UnityEngine;

public class HealthPad : MonoBehaviour {
    public Health health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void FixedUpdate() {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(float damage) {
        currentHealth -= damage;
    }

    private void OnCollisionStay(Collision target) {
        if (target.collider.gameObject.layer == LayerMask.NameToLayer("Player") && health.currentHealth + 1 < 100) {
            TakeDamage(0.1f);
        }
    }
}