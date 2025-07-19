using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float firingRange = 20f;
    [SerializeField] private float fireCooldown = 2f;
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private Transform leftCannonSpawn;
    [SerializeField] private Transform rightCannonSpawn;
    [SerializeField] private float cannonForce = 50f;
    private float fireTimer;
    [SerializeField] private float alignmentThreshold = 0.9f; 
    [SerializeField] private float desiredBroadsideDistance = 12f;
    [SerializeField] private float lateralAdjustSpeed = 5f;
    [SerializeField] private float alignmentSpeed = 2f;
    [SerializeField] private float distanceTolerance = 5f;
    [SerializeField] private AudioClip cannonFireClip;
    [SerializeField] private AudioSource audioSource;

    void Update()
    {
        if (target == null) return;

        Vector3 toPlayer = target.position - transform.position;
        float distanceToPlayer = toPlayer.magnitude;

        // Step 1: Stay alongside the player (maintain parallel offset)
        Vector3 playerRight = target.right;
        Vector3 desiredOffsetPosition = target.position + playerRight * desiredBroadsideDistance;

        Vector3 moveDirection = (desiredOffsetPosition - transform.position);
        if (moveDirection.magnitude > distanceTolerance)
        {
            transform.position += moveDirection.normalized * lateralAdjustSpeed * Time.deltaTime;
        }

        // Step 2: Match rotation with player (stay parallel)
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, alignmentSpeed * Time.deltaTime);

        // Step 3: Fire when aligned and in range
        fireTimer -= Time.deltaTime;
        if (distanceToPlayer < firingRange && fireTimer <= 0f)
        {
            float sideAlignment = Vector3.Dot(-transform.right, (target.position - transform.position).normalized);

            if (sideAlignment > alignmentThreshold)
            {
                FireCannon(leftCannonSpawn, -transform.right);
            }
            else if (Vector3.Dot(transform.right, (target.position - transform.position).normalized) > alignmentThreshold)
            {
                FireCannon(rightCannonSpawn, transform.right);
            }

            fireTimer = fireCooldown;
        }
    }

    private void FireCannon(Transform spawnPoint, Vector3 direction)
    {
        if (spawnPoint == null || cannonballPrefab == null) return;

        GameObject cannonball = Instantiate(cannonballPrefab, spawnPoint.position + direction.normalized, Quaternion.identity);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(direction.normalized * cannonForce, ForceMode.Impulse);
        }

        if (audioSource != null && cannonFireClip != null)
        {
            audioSource.PlayOneShot(cannonFireClip);
        }
    }
}
