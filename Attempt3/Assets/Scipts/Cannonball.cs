using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    [SerializeField] private float lifespan = 5f;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        if (audioSource != null && hitClip != null)
        {
            audioSource.PlayOneShot(hitClip);
        }
        
        Destroy(gameObject);
    }
}
