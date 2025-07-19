using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameManager gameMng;
    // get static game manager
    void Start()
    {
        gameMng = GameManager.Instance;
    }
    // update coin value and destroy chest
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            gameMng.getCoin(5);
            Destroy(this);
        }
    }
}
