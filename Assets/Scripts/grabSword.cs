using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabSword : MonoBehaviour
{
    private int index; //for sword index of this exact player
    private bool flag = true;
    [SerializeField] GameObject rhand;
    [SerializeField] GameObject lhand;
    private bool isNotEquipped = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("endCartLocation") && flag)
        {
            index = int.Parse(transform.name.Replace("end", ""));
            LeanTween.cancel(CartController.leanMovesOfEndGameCharacters[index / 2].id);

            try
            {
                GameObject empty = new GameObject();
                if (CartController.swords.Count - 1 >= index)
                {
                    gameObject.GetComponent<Animator>().Play("Idle");
                    //empty.transform.parent = rhand.transform;
                    CartController.swords[index].transform.parent = null;
                    CartController.swords[index].transform.parent = transform;
                    //CartController.swords[index].transform.parent = rhand.transform;

                    //move chest loc start
                    CartController.swords[index].transform.localScale = new Vector3(1, 1, 1);
                    LeanTween.rotateLocal(CartController.swords[index], new Vector3(0, 0, 0), 1f);
                    LeanTween.moveLocal(CartController.swords[index], new Vector3(0, 1f, 0), 1f).setOnComplete(() =>
                    {
                        //move chest loc end
                        //move hand start
                        CartController.swords[index].transform.parent = rhand.transform;
                        LeanTween.rotateLocal(CartController.swords[index], new Vector3(0, 0, 0), 1f);
                        LeanTween.moveLocal(CartController.swords[index], new Vector3(0, 0, 0), 1f);
                    });



                }
                if (CartController.swords.Count - 1 >= index + 1)
                {

                    isNotEquipped = false;
                    //empty.transform.parent = lhand.transform;
                    CartController.swords[index + 1].transform.parent = null;
                    CartController.swords[index + 1].transform.parent = transform;

                    //move chest loc start
                    CartController.swords[index + 1].transform.localScale = new Vector3(1, 1, 1);
                    LeanTween.rotateLocal(CartController.swords[index + 1], new Vector3(0, 0, 0), 1f);
                    LeanTween.moveLocal(CartController.swords[index + 1], new Vector3(0, 1f, 0), 1f).setOnComplete(() =>
                    {
                        //move chest loc end
                        //move hand start
                        CartController.swords[index + 1].transform.parent = lhand.transform;
                        LeanTween.rotateLocal(CartController.swords[index + 1], new Vector3(150, 0, 0), 1f);


                        LeanTween.moveLocal(CartController.swords[index + 1], new Vector3(0, 0, 0), 1f).setOnComplete(() =>
                        {
                            //run to endgamelocation
                            gameObject.GetComponent<Animator>().Play("Sword Sprint");
                            transform.LookAt(GameObject.FindGameObjectWithTag("endGameLocation").transform.position);
                            LeanTween.move(gameObject, GameObject.FindGameObjectWithTag("endGameLocation").transform.position, 5f);
                        });
                    });
                }
                if (isNotEquipped)
                {

                    //if (CartController.swords.Count - 1 >= index)
                    //{
                    //    CartController.swords[index].transform.parent = null;
                    //    CartController.swords[index].AddComponent<Rigidbody>();
                    //}
                    transform.LookAt(GameObject.FindGameObjectWithTag("endGameLocationRun").transform.position);
                    LeanTween.move(gameObject, GameObject.FindGameObjectWithTag("endGameLocationRun").transform.position, 5f);
                }
                flag = false;
            }
            catch (System.Exception)
            {
                Debug.Log(transform.name);
                throw;
            }

        }

        if (other.CompareTag("endGameLocation"))
        {
            EventManager.Instance.Score += 1;
            EventManager.Instance.deScore--;
        }
        if (other.CompareTag("endGameLocationRun"))
        {
            EventManager.Instance.deScore--;
        }
    }
}
