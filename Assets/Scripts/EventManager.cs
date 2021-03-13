using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void DropAction();
    public static event DropAction OnDrop;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    private bool GameStatus = true;
    [SerializeField] GameObject player;

    public void Awake()
    {
        Screen.SetResolution(1080, 1920, true);
    }
    public void GameStart()
    {
        if(GameStatus)
        {
            OnClicked?.Invoke();
            GameStatus = false;
        }
    }
    public static void DropItems()
    {
        OnDrop?.Invoke();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
                                           player.transform.position + new Vector3(0, 4, -10),
                                           5f * Time.deltaTime);
    }
}
