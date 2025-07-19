using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public float coin;
    public int shipLevel;
    public float kills;
    public float power;
    public Vector3 spawnPnt;

    [Header("Prefabs")]
    public GameObject shipMedium;
    public GameObject shipLarge;
    public GameObject enemy;

    [Header("UI")]
    public TMP_Text killsText;
    public TMP_Text powerText;
    public TMP_Text coinText;

    private GameObject Player;
    private float enemyCount;
    private float maxEnemy;

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
    }
    //Update runs each frame
    void Update()
    {
        spawnEnemy();
    }
    // run on button press to buy ship
    public void buyShip(int ship, float cost)
    {
        if (shipLevel != ship && coin >= cost)
        {
            shipLevel = ship;
            loseCoin(cost);
            setShip();
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
    }
    // increase coin when collecting chest
    public void getCoin(float amt)
    {
        coin += amt;
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
    }
    // spawn enemy when below max enemies
    public void spawnEnemy()
    {
        if (enemyCount < maxEnemy)
        {
            Instantiate(enemy, spawnPnt, enemy.transform.rotation);
        }
    }
}
