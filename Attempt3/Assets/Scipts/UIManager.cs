using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject Controls;
    // on control button press
    public void controlPress()
    {
        if (Controls.activeSelf)
        {
            Controls.SetActive(false);
        } else
        {
            Controls.SetActive(true);
        }
    }
    // on start button press
    public void startPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
