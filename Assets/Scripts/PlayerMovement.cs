using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch _touch;
    private Vector2 _touchPosStart, _touchPosEnd;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchInput();
    }


    void touchInput()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                // LeanTween.moveX(player, transform.position.x + _touch.deltaPosition.x * 0.02f, 0.1f);
                transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * 0.003f, transform.position.y, transform.position.z);
            }
        }
    }





    private void OnEnable()
    {
        EventManager.OnClicked += StartMove;
    }

    private void OnDisable()
    {
        EventManager.OnClicked -= StartMove;
    }
    void StartMove()
    {
        LeanTween.moveZ(this.gameObject, 420, 20);
    }
}
