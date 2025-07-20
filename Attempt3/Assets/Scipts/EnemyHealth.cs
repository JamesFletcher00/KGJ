using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    public GameObject chestDrop;
    private GameManager gameMngr;

    void Start()
    {
        currentHealth = maxHealth;
        gameMngr = GameManager.Instance;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy Health" + currentHealth);

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
