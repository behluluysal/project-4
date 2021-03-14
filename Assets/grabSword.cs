using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabSword : MonoBehaviour
{
    private int index; //for sword index of this exact player
    private bool flag = true;
    [SerializeField] GameObject rhand;
    [SerializeField] GameObject lhand;
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
        if(other.CompareTag("endCartLocation") && flag)
        {
            gameObject.GetComponent<Animator>().Play("Idle");
            try
            {
                index = int.Parse(transform.name.Replace("end", ""));
                if (CartController.swords.Count - 1 >= index)
                {
                    CartController.swords[index].transform.parent = rhand.transform;
                    LeanTween.moveLocal(CartController.swords[index], new Vector3(0,0,0), 1f).setOnComplete(() => {                     });
                    CartController.swords[index].transform.localScale = new Vector3(1,1,1);
                    LeanTween.rotateLocal(CartController.swords[index], new Vector3(0, 0, 0),1f);
                }
                if (CartController.swords.Count - 1 >= index + 1)
                {
                    CartController.swords[index+1].transform.parent = lhand.transform;
                    LeanTween.moveLocal(CartController.swords[index+1], new Vector3(0, 0, 0), 1f).setOnComplete(() => { });
                    CartController.swords[index+1].transform.localScale = new Vector3(1, 1, 1);
                    LeanTween.rotateLocal(CartController.swords[index+1], new Vector3(150, 0, 0), 1f);
                }
                flag = false;
            }
            catch (System.Exception)
            {
                Debug.Log(transform.name);
                throw;
            }
            
        }
    }
}
