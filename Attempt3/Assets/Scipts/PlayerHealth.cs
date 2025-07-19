using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float baseMaxHealth = 100f;
    [SerializeField] private float mediumMaxHealth = 150f;
    [SerializeField] private float largeMaxHealth = 250f;
    private float currentHealth;
    private float currentMaxHealth;
    void Start()
    {
        SetShipSize("Base");
    }

    public void SetShipSize(string size)
    {
        switch (size)
        {
            case "Medium":
                currentMaxHealth = mediumMaxHealth;
                break;
            case "Large":
                currentMaxHealth = largeMaxHealth;
                break;
            default:
                currentMaxHealth = baseMaxHealth;
                break;
        }
        currentHealth = currentMaxHealth;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
