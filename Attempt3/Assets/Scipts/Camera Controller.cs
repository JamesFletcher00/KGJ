using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform FollowTarget, LookTarget;
    public float FollowSpeed = 10f;
    private GameObject Player;
    private Transform currentChild;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        currentChild = Player.transform.Find("CameraHolder");
    }

    public void LateUpdate()
    {
        
        LookTarget = Player.transform;
        FollowTarget = currentChild;
        Vector3 targetPosition = FollowTarget.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);

        transform.LookAt(LookTarget);
    }

    public void updatePlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        currentChild = Player.transform.Find("CameraHolder");
    }
}
