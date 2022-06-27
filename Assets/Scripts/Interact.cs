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


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("e")){
            if(Physics.SphereCast(cam.position, 1, cam.forward, out hit, distance, mask)){
                if(hit.transform.gameObject.GetComponent<ItemPickup>() != null){
                    GameObject g = hit.transform.gameObject;
                    ItemPickup i = g.GetComponent<ItemPickup>();
                    inventory.InventorySystem.AddToInventory(i.ItemData, 1);
                    Destroy(g);

                }
            }
        }
    }
}
