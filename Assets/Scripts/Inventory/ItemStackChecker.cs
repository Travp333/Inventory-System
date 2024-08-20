using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemStackChecker : MonoBehaviour
{
    int count;
    
    public void StopCR(){
        StopAllCoroutines();
    }
    IEnumerator DelayedDelete(Collider other, pickUpableItem pickUp, pickUpableItem otherPickUp)
    {
        yield return new WaitForSeconds(Random.Range(.1f, .3f));
        if(other != null){
            if(otherPickUp != null){
                count = otherPickUp.count;
                if(pickUp.count + count <= pickUp.item.stackSize){
                    if(!pickUp.block){
                        Destroy(other.transform.parent.gameObject);
                        otherPickUp.block = true;
                        other.gameObject.GetComponentInChildren<ItemStackChecker>().StopCR();
                        pickUp.EditCount(pickUp.count + count, otherPickUp.gameObject.name);
                        Debug.Log("Deleted Valid other object (" + otherPickUp.gameObject.name + ") now have " + pickUp.count + " " + pickUp.item.name, transform.parent.gameObject);
                    }
                }

            }
        }
    }
    //DOESNT WORK WHEN YOU TRY TO PICK UP AN ITEM WITH A FULL INVENTORY AND IT DROPS BACK ON THE GROUND
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("CollisioN!");
        //is this a valid object?
        if(other.GetComponent<ItemStackChecker>()!= null){
            //Debug.Log("Collision with valid Object " + other.GetComponent<ItemStackChecker>().transform.parent.name);
            //are these two of the same type?
            pickUpableItem otherPickUp;
            pickUpableItem pickUp;
            otherPickUp = other.transform.parent.gameObject.GetComponent<pickUpableItem>();
            pickUp = transform.parent.gameObject.GetComponent<pickUpableItem>();
            if(otherPickUp.item.name == pickUp.item.name){
                //Debug.Log("Collision with " + count + " of same item " + pickUp.item, transform.parent.gameObject);
                if(other.transform.parent.gameObject != null){
                    if(!pickUp.block){
                        
                    }
                }
            }
        }
    }
}
