using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCart : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject[] weapons;
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
        if(other.CompareTag("Finish"))
        {
            
        }
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        
        for(int i = 0; i<spawners.Length;i++)
        {
            GameObject gameObject;
            gameObject = (GameObject)Instantiate(weapons[Random.Range(0,4)], spawners[i].transform.position, Quaternion.identity);
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Cart").transform);
            gameObject.transform.localScale = new Vector3(1.7f,1.5f,1.5f);
            LeanTween.rotateX(gameObject, -75, 1f).setEaseInOutSine();
            LeanTween.rotateY(gameObject, 80, 1f).setEaseInOutSine();
            LeanTween.rotateZ(gameObject, -70, 1f).setEaseInOutSine();
        }
    }
}
