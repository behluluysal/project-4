using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public int Score = 0;
    public int deScore = 10;
    public int level = 1;
    [SerializeField]private TextMeshProUGUI scoreText;
    public delegate void DropAction();
    public static event DropAction OnDrop;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    private bool GameStatus = true;
    [SerializeField] GameObject player;

    public void Awake()
    {
        Screen.SetResolution(1080, 1920, true);
        if (Instance == null)
        {

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameStart()
    {
        
    }
    public static void DropItems()
    {
        OnDrop?.Invoke();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
                                           player.transform.position + new Vector3(0, 5, -15),
                                           5f * Time.deltaTime);
        if (deScore == 0 || (5 - level - Score)<=0)
        {
            if((5 - level - Score) <= 0)
                scoreText.text = "Level Complete!";
            else
                scoreText.text = "You failed!";
        }
        else
        {
            scoreText.text = "Soldiers Needed: " + (5-level-Score);
        }

        
        if (GameStatus && (Input.touchCount >= 1))
        {
            GameObject.Find("Button").SetActive(false);
            player.GetComponent<Animator>().Play("Sword Sprint");
            OnClicked?.Invoke();
            GameStatus = false;
        }
    }
}
