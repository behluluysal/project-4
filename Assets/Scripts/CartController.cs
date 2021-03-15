using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    // Start is called before the first frame update
    private  Transform[] swordsTemp;
    public static List<GameObject> swords = new List<GameObject>();
    public static LTDescr[] leanMovesOfEndGameCharacters;
    void Start()
    {
        leanMovesOfEndGameCharacters = new LTDescr[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            swordsTemp = GameObject.FindGameObjectWithTag("PlayerCart").GetComponentsInChildren<Transform>();
            for(int i = 0; i< swordsTemp.Length;i++)
            {
                if(swordsTemp[i].tag == "sword")
                swords.Add(swordsTemp[i].gameObject);
            }
            GameObject parent = GameObject.Find("EndGameCharacters");
            GameObject cart = GameObject.Find("endCartLocation");
            GameObject[] allChildren = GameObject.FindGameObjectsWithTag("endCharacter");
            transform.parent = parent.transform;
            foreach(GameObject child in allChildren)
            {
                if (child.name != "endCartLocation" )
                {
                    //LeanTween.moveLocalZ
                    //change stance of player, equip sword and run
                    //make front cart destroyed
                    //make other characters move to player chart, equip weapon and run to war
                    //finish the game
                    //Vector3 qTo = (child.transform.position - transform.position);
                    //LeanTween.rotate(child.gameObject ,qTo,1f);
                    //parent.transform.position = new Vector3(-7, 0, 442.6f);
                    //parent.transform.rotation = new Quaternion(0, 0, 0, 0);
                    child.transform.LookAt(cart.transform.position);
                    
                    LTDescr descr = LeanTween.move(child.gameObject, cart.transform.position,Random.Range(2,5));
                    child.transform.position = new Vector3(child.transform.position.x, 0, child.transform.position.z);
                    leanMovesOfEndGameCharacters[int.Parse(child.transform.name.Replace("end", ""))/2] = descr;
                }
                
            }
            
        }
    }
}
