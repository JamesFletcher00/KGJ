using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    public float MovementSpeed = 10, RotationSpeed = 50f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move()
    {
        Vector3 move = transform.forward * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);

    }
    public void Rotate(float rotationInput)
    {
        float rotationAmount = rotationInput * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }

}
