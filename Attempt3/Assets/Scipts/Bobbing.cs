using UnityEngine;

public class Bobbing : MonoBehaviour
{
    [Header("Variables")]
    public float bobSpeed = 2f;
    public float upAmount = 0.5f;
    public float downAmount = 0.5f;
    public float allowance = 0.08f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, upAmount, 0);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, bobSpeed * Time.deltaTime);

        // If close to target, switch direction
        if (Vector3.Distance(transform.position, targetPos) < allowance)
        {
            if (movingUp)
                targetPos = startPos - new Vector3(0, downAmount, 0);
            else
                targetPos = startPos + new Vector3(0, upAmount, 0);

            movingUp = !movingUp;
        }
    }
}
