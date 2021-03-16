using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    

    /*Drop item between -4,5 according to it's parent x axis, z-2 to drop and y 0*/
    void DropItem()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        LeanTween.moveX(this.gameObject, Random.Range(-4, 3), 0.5f);
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
        if(gameObject.transform.parent.name != "PlayerCart")
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.OnDrop -= DropItem;
            CancelInvoke("DestroyMe");
            gameObject.transform.parent = GameObject.FindGameObjectWithTag("PlayerCart").transform;
            gameObject.GetComponent<Collider>().enabled = false;
            LeanTween.moveLocalY(this.gameObject, 2.5f, 0.5f).setOnComplete(() => {
                gameObject.transform.localScale = new Vector3(5f, 5f, 5f);
                LeanTween.moveLocalX(gameObject, Random.Range(-1.4f, 2.5f), 1f);
                LeanTween.moveLocalZ(gameObject, Random.Range(-2, 1f), 1f).setEaseInOutSine();
                LeanTween.rotateLocal(gameObject, new Vector3(0,0,0),1f);
            }) ;
        }
    }
}
