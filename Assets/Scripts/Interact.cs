using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    [SerializeField]
    LayerMask mask = default;
    public float distance;
    public Transform cam;
    RaycastHit hit;

    public InventoryHolder inventory;
    void Update()
    {
        
        if (Input.GetKeyDown("e")){
            if(Physics.SphereCast(cam.position, 1, cam.forward, out hit, distance, mask)){
                if(hit.transform.gameObject.GetComponent<ItemPickup>() != null){
                    GameObject g = hit.transform.gameObject;
                    ItemPickup i = g.GetComponent<ItemPickup>();

                    //I changed this to only destroy the object if the item is actually added to your inventory. also added an error message for when you have no more space. 
                    //this mostly works - trav
                    
                    if(inventory.InventorySystem.AddToInventory(i.ItemData, 1)){
                        Destroy(g);
                    }
                    else{
                        Debug.Log("inventory full!");
                    }

                }
            }
        }
    }
}
