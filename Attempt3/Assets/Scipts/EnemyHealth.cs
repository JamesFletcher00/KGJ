using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private GameObject chestDrop;
    [SerializeField] private GameManager gameMngr;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        if (chestDrop != null)
        {
            Instantiate(chestDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        gameMngr.setKillsAndPower();
    }
}
