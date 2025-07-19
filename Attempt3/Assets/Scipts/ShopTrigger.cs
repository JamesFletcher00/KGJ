using UnityEngine;
using UnityEngine.UI;
public class ShopTrigger : MonoBehaviour
{
    public PlayerMovement CharacterController;
    public GameObject upgradeButton;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CharacterController.isAnchorDropped)
        {
            upgradeButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            upgradeButton.SetActive(false);
        }
    }
}
