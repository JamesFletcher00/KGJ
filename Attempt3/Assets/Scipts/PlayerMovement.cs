using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    public float MovementSpeed = 10f, RotationSpeed = 10f;
    private float currentSpeedMult = 1f;
    [SerializeField] private float accelerationRate = 0.2f;
    [SerializeField] private float minSpeedMult = 0f;
    [SerializeField] private float maxSpeedMult = 1f;

    public bool isAnchorDropped = false;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void ToggleAnchor()
    {
        //anchor = GameObject.FindGameObjectWithTag("Anchor");
        isAnchorDropped = !isAnchorDropped;
        GameManager.Instance.anchorDis();
    }

    public void Move()
    {
        // Smoothly increase or decrease speed based on anchor state
        float target = isAnchorDropped ? minSpeedMult : maxSpeedMult;
        currentSpeedMult = Mathf.MoveTowards(currentSpeedMult, target, accelerationRate * Time.deltaTime);

        Vector3 move = transform.forward * MovementSpeed * currentSpeedMult * Time.deltaTime;
        _characterController.Move(move);
    }

    public void Rotate(float rotationInput)
    {
        float rotationAmount = rotationInput * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }

}
