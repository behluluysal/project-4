using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabSword : MonoBehaviour
{
    private int index; //for sword index of this exact player
    private bool flag = true;
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
            try
            {
                index = int.Parse(transform.name.Replace("end", ""));
                if (CartController.swords.Count - 1 >= index)
                {
                    CartController.swords[index].SetActive(false);
                }
                if (CartController.swords.Count - 1 >= index + 1)
                {
                    CartController.swords[index + 1].SetActive(false);
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
