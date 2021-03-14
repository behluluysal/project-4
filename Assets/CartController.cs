using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameObject characters = GameObject.Find("EndGameCharacters");
            transform.parent = null;
            foreach(Transform child in transform)
            {
                //LeanTween.moveLocalZ
                //change stance of player, equip sword and run
                //make front cart destroyed
                //make other characters move to player chart, equip weapon and run to war
                //finish the game
            }
        }
    }
}
