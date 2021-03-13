using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    

    /*Drop item between -4,5 according to it's parent x axis, z-2 to drop and y 0*/
    void DropItem()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        LeanTween.moveX(this.gameObject, Random.Range(-5, 4), 0.5f);
        LeanTween.moveY(this.gameObject, 0, 0.5f);
        LeanTween.moveZ(this.gameObject, transform.position.z -2, 0.5f).setOnComplete(()=> { gameObject.transform.parent = null; Invoke("DestroyMe", 2.0f); });
    }

    private void OnDestroy()
    {
        EventManager.OnDrop -= DropItem;
    }

    private void OnEnable()
    {
        EventManager.OnDrop += DropItem;
    }

    private void DestroyMe()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.OnDrop -= DropItem;
            CancelInvoke("DestroyMe");
            gameObject.transform.parent = GameObject.FindGameObjectWithTag("PlayerCart").transform;
            LeanTween.moveY(this.gameObject, 2, 0.5f).setOnComplete(() => {
                LeanTween.moveX(gameObject, Random.Range(-1, 2), 1f);
                LeanTween.moveY(gameObject, 0, 1f).setEaseInOutSine();
                LeanTween.rotateY(gameObject, 90, 1f).setEaseInOutSine();
            }) ;
        }
    }
}
