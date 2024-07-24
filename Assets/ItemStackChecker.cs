using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemStackChecker : MonoBehaviour
{
    public bool block;
    private void OnTriggerEnter(Collider other)
    {
        if(!block){
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
                    int count; 
                    count = otherPickUp.count;
                    Debug.Log("Collision with " + count + " of same item " + pickUp.item, transform.parent.gameObject);
                    //if yes, delete the "other" one
                    if(other.transform.parent.gameObject != null){
                        if(pickUp.count + count <= pickUp.item.stackSize){
                            if(!block){
                                other.GetComponent<ItemStackChecker>().block = true;
                                Destroy(other.transform.parent.gameObject);
                                pickUp.EditCount(pickUp.count + count);
                                Debug.Log("Deleted Valid other object, now have " + pickUp.count + " " + pickUp.item.name, transform.parent.gameObject);
                            }
                        }
                    }
                }
            }
        }
    }

}
