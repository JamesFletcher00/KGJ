using UnityEngine;

public class SafeZoneTrigger : MonoBehaviour
{
    private string originalTag = "Player";

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(originalTag))
        {
            other.tag = "Safe";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Safe") && other.GetComponent<InputHandler>() != null)
        {
            other.tag = originalTag;
        }
    }
}
