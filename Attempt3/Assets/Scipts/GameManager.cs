using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public float coin;
    public int shipLevel;
    public float kills;
    public float power;
    public Transform[] spawnPoints;
    private int nextShip = 1;

    [Header("Prefabs")]
    public GameObject shipMedium;
    public GameObject shipLarge;
    public GameObject enemy;

    [Header("UI")]
    public TMP_Text killsText;
    public TMP_Text powerText;
    public TMP_Text coinText;
    public GameObject tutorial;
    public CameraController camControl;
    public GameObject anchor;

    public GameObject Player;
    private float enemyCount;
    public float maxEnemy;

    public static GameManager Instance;
    // initialise instance
    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coin = 0;
        shipLevel = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(HidePopUp(tutorial));
    }
    //Update runs each frame
    void Update()
    {
        spawnEnemy();
    }
    // run on button press to buy ship
    public void buyShip()
    {
        if (shipLevel != nextShip && coin >= 50)
        {
            shipLevel = nextShip;
            loseCoin(50);
            setShip();
            nextShip = 2;
        }
    }
    // set ship type, instantiate in new prefab
    public void setShip()
    {
        if (shipLevel == 1)
        {
            Instantiate(shipMedium, Player.transform.position, Player.transform.rotation);
        }
        else
        {
            Instantiate(shipLarge, Player.transform.position, Player.transform.rotation);
        }
        Destroy(Player);
        setPlayer();
        camControl.updatePlayer();
    }
    // increase coin when collecting chest
    public void getCoin(float amt)
    {
        coin += amt;
        Debug.Log("Coin: " + coin);
        coinText.text = coin.ToString();
    }
    // lost coin when spending
    public void loseCoin(float amt)
    {
        coin -= amt;
    }
    // set new ship to player
    public void setPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // sets kills and power for tracking
    public void setKillsAndPower()
    {
        kills++;
        power += 5;
        // update enemy count
        enemyCount--;
        killsText.text = kills.ToString();
    }
    // spawn enemy when below max enemies
    public void spawnEnemy()
    {
        if (enemyCount < maxEnemy)
        {
            StartCoroutine(spawnDelay());
            for (int i = 0; i < spawnPoints.Length && enemyCount < maxEnemy; i++)
            {
                Instantiate(enemy, spawnPoints[i].position, spawnPoints[i].rotation);
                enemyCount++;
            }
            Debug.Log("Enemy spawned");
        }
    }
    //spawn delay
    IEnumerator spawnDelay()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2f);
    }
    //hide popups
    IEnumerator HidePopUp(GameObject text)
    {
        yield return new WaitForSecondsRealtime(5f);//this waits for the popup duration value
        text.SetActive(false);//hides popup
    }
    // anchor display
    public void anchorDis()
    {
        if (!anchor.activeSelf)
        {
            anchor.SetActive(true);
        }
        else
        {
            anchor.SetActive(false);
        }
    }
}
