using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public float coin;
    public int shipLevel;
    public float kills;
    public float power;

    [Header("Prefabs")]
    public GameObject shipMedium;
    public GameObject shipLarge;

    [Header("UI")]
    public TMP_Text killsText;
    public TMP_Text powerText;

    private GameObject Player;

    public static GameManager Instance;

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
    }
}
