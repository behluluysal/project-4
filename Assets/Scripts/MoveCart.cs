using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCart : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
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
        LeanTween.moveZ(this.gameObject, 440, 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WayPoint"))
        {
            EventManager.DropItems();
            StartCoroutine(WaitAndSpawn(2f));
        }
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        
        for(int i = 0; i<6;i++)
        {
            GameObject gameObject;
            gameObject = (GameObject)Instantiate(Resources.Load("Cube"), spawners[i].transform.position, Quaternion.identity);
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Cart").transform);
        }
    }
}
