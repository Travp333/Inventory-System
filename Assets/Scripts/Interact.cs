using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    [SerializeField]
    LayerMask mask = default;

    [SerializeField]
    SimpleCameraMovement camScript = null; 
    [SerializeField]
    GameObject InventoryUI = null; //Inventory Canvas
    public float distance;
    public Transform cam;
    RaycastHit hit;
    Inven inv;
    Item item;
    bool invIsOpen = false;

    //public InventoryHolder inventory;
    void Start()
    {
        inv = this.gameObject.GetComponent<Inven>();
        camScript = this.gameObject.GetComponent<SimpleCameraMovement>();
        InventoryUI.SetActive(false); //Inventory is off when you start
    }
    void Update()
    {
        //Check Inventory
        if (invIsOpen)
        {
            if (Input.GetKeyDown("tab")) //pressing tab with the inventory open 
            {
                
                InventoryUI.SetActive(false); //close inventory
                camScript.enabled = true;//enable camera movement script
                invIsOpen = false;
            }
        }
        else if (!invIsOpen) //inventory is not open
        {
            if (Input.GetKeyDown("tab"))
            {
                InventoryUI.SetActive(true);//open inventory 
                camScript.enabled = false;//disable camera movement script
                invIsOpen = true;
            }


            //Drop items
            if (Input.GetKeyDown("x"))
            {
                inv.DropItem();
            }
            //pickup Items
            if (Input.GetKeyDown("e"))
            {
                if (Physics.SphereCast(cam.position, 1, cam.forward, out hit, distance, mask))
                {
                    if (hit.transform.gameObject.GetComponent<pickUpableItem>() != null)
                    {
                        item = hit.transform.gameObject.GetComponent<pickUpableItem>().item;
                        Debug.Log("Hit a pickuppable item --------------------------------------------");
                        inv.PickUp(item);
                        if (inv.isPickedUp)
                        {
                            Destroy(hit.transform.gameObject);
                            inv.isPickedUp = false;
                        }
                        else
                        {
                            Debug.Log("Inventory full!");
                        }


                    }
                }
            }
        }
    }
    void LogInventory() {
        Debug.Log("*********************************");
        Debug.Log("Inventory:");
        //iterating through columns
        for (int i = 0; i < inv.hSize; i++)
        {
            //iterating through rows
            for (int i2 = 0; i2 < inv.vSize; i2++)
            {
                if (inv.array[i, i2].Name == "Empty")
                {
                    Debug.Log("Slot (" + i + " , " + i2 + " ) contains nothing");
                }
                else
                {
                    Debug.Log("Slot (" + i + " , " + i2 + " ) contains " + inv.array[i, i2].Amount + " " + inv.array[i, i2].Name);
                }

            }
        }
        Debug.Log("****************************************");
    }
}
