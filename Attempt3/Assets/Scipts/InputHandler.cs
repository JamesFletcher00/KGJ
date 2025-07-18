using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement CharacterController;
    private InputAction _moveAction, _fireLeftCannon, _fireRightCannon;
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private Transform leftCannonSpawn;
    [SerializeField] private Transform rightCannonSpawn;
    [SerializeField] private Transform shipTransform;

    [SerializeField] private float cannonForce = 500f;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _fireLeftCannon = InputSystem.actions.FindAction("FireLeft");
        _fireRightCannon = InputSystem.actions.FindAction("FireRight");

        _fireLeftCannon.performed += ctx => FireLeft();
        _fireRightCannon.performed += ctx => FireRight();

        _fireLeftCannon.Enable();
        _fireRightCannon.Enable();

        if (CharacterController == null)
            CharacterController = GetComponent<PlayerMovement>();

        Cursor.visible = false;
    }

    void Update()
    {

        if (CharacterController == null)
        {
            Debug.LogError("CharacterController is null!");
            return;
        }
        float horizontalInput = _moveAction.ReadValue<Vector2>().x;

        CharacterController.Rotate(horizontalInput);
        CharacterController.Move(); // Always move forward
    }

    private void FireLeft()
    {
        FireCannon(leftCannonSpawn.position, -shipTransform.right); // fire to the ship's left
    }

    private void FireRight()
    {
        FireCannon(rightCannonSpawn.position, shipTransform.right); // fire to the ship's right
    }

    private void FireCannon(Vector3 position, Vector3 direction)
    {
        GameObject cannonball = Instantiate(cannonballPrefab, position, Quaternion.identity);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction.normalized * cannonForce);
        }

        Debug.DrawRay(position, direction * 5f, Color.red, 2f); // Should now be visible
    }

}