using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script handles the interaction of the player character with objects in environment, like inventory objects
//Written by Conor and Travis

//BIG TODO
//close storage inventory if you get too far away from the object

public class Interact : MonoBehaviour
{
	//reference to the tempHolder script
	tempHolder tempSlot;
	//Mask for the Raycast
    [SerializeField]
	LayerMask mask = default;
	// Reference to the  Camera Controller
    [SerializeField]
	SimpleCameraMovement camScript = null; 
	//reference to the player UI
	[SerializeField]
	GameObject InventoryUI = null; //Inventory Canvas
	//raycast length;
	public float distance;
	//camera position
	public Transform cam;
	//raycast hit holder
	RaycastHit hit;
	//reference to Inventory Script on Player
	Inven inv;
	// holder for inventory Items
	Item item;
	//bool to track inventory being open and closed
	bool invIsOpen = false;
	//List of every other inven script in the level
	[SerializeField]
	public List<GameObject> StorageInvenUI = new List<GameObject>();
	//tracks if a storage device's inventory is open
	public bool storageInvOpen = false;
	bool distanceGate = false;
	Transform storageObjectPos;
	[SerializeField]
	[Tooltip("The distance that the Inventory closes when walking away from an open storage object")]
	float invRange;
	[SerializeField]
	[Tooltip("How wide the sphere is that is cast from the player when hitting e")]
	float sphereCastRadius = .5f;
    void Start()
	{
		//plugging references
		tempSlot = this.gameObject.GetComponent<tempHolder>();
        inv = this.gameObject.GetComponent<Inven>();
		camScript = this.gameObject.GetComponent<SimpleCameraMovement>();
		//disable all Inventory UI
		HideAllInventories();

	}
	public void HideAllInventories(){
		//Loop through all the UIPlugger objects in the scene and add them to a list while also disabling them.
		foreach(UiPlugger g in GameObject.FindObjectsOfType<UiPlugger>()){
			//avoids adding duplicates
			if(g.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true){
				if(StorageInvenUI.Contains(g.gameObject.transform.GetChild(0).gameObject)){
					//Debug.Log("Just hiding UI");
					g.gameObject.transform.GetChild(0).gameObject.SetActive(false);
				}
				else{
					//Debug.Log("Hiding Ui and Adding to list");
					StorageInvenUI.Add(g.gameObject.transform.GetChild(0).gameObject);
					g.gameObject.transform.GetChild(0).gameObject.SetActive(false);
				}
			}
		}
	}
	public void HideAllNonPlayerInventories(){
		//Loop through all the UIPlugger objects in the scene and add them to a list while also disabling them.
		foreach(UiPlugger g in GameObject.FindObjectsOfType<UiPlugger>()){
			//avoids adding duplicates
			if(g.gameObject.tag != "Player"){
				if(g.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true){
					if(StorageInvenUI.Contains(g.gameObject.transform.GetChild(0).gameObject)){
						//Debug.Log("Just hiding UI");
						g.gameObject.transform.GetChild(0).gameObject.SetActive(false);
					}
					else{
						//Debug.Log("Hiding Ui and Adding to list");
						StorageInvenUI.Add(g.gameObject.transform.GetChild(0).gameObject);
						g.gameObject.transform.GetChild(0).gameObject.SetActive(false);
					}
				}
			}
		}
	}
	//open up the player's Inventory
	void OpenInventory(){
		//makes sure the temp slot is empty
		tempSlot.ClearSlot();
		//puts cursor on screen
		Cursor.lockState = CursorLockMode.None;
		//unhides cursor
		Cursor.visible = true;
		//enables UI object
		InventoryUI.SetActive(true);
		//disable camera movement script
		camScript.enabled = false;
		invIsOpen = true;
		
	}
	void DistanceCheck(){
		if(Vector3.Distance(this.transform.position, storageObjectPos.position) > invRange){
			Debug.Log("TOO FAR!!!!!");
			distanceGate = false;
			storageObjectPos = null;
			HideAllNonPlayerInventories();
			tempSlot.ClearSlot();
			storageInvOpen = false;
		}
	}
	
	//closes out the inventory and all open storage inventories, mostly just inverse of above
	void CloseInventory(){
		tempSlot.ClearSlot();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		camScript.enabled = true;//enable camera movement script
		invIsOpen = false;
		HideAllInventories();
		storageInvOpen = false;
	}
	
    void Update()
	{
		//Debug.Log(inv.isPickedUp);
        //Check Inventory
        if (invIsOpen)
        {
        	//pressing tab with the inventory open 
            if (Input.GetKeyDown("tab")) 
            {
	            CloseInventory();
            }
        }
        else if (!invIsOpen) 
        {
        	//inventory is not open
            if (Input.GetKeyDown("tab"))
            {
	            OpenInventory();
            }

            //pickup Items
            if (Input.GetKeyDown("e"))
            {
                if (Physics.SphereCast(cam.position, sphereCastRadius, cam.forward, out hit, distance, mask))
                {
	                //IF the the thing you hit is a button
	                if (hit.transform.gameObject.GetComponent<buttonPush>() != null)
	                {
		                //Get the button object
		                buttonPush button = hit.transform.gameObject.GetComponent<buttonPush>();
		                if ((button.oneTime && button.anim.GetBool("onePush") == false) || !button.blocker)
		                {
			                button.press();
		                }
	                }
                	//hit a pickupable item?
                    if (hit.transform.gameObject.GetComponent<pickUpableItem>() != null)
                    {
                    	//store reference to the hit object
	                    item = hit.transform.gameObject.GetComponent<pickUpableItem>().item;
	                    //update UI
	                    inv.SmartPickUp(item);
	                    //Checks if the object was successfully picked up
                        if (inv.isPickedUp)
                        {
                        	//despawn object in the world
                            Destroy(hit.transform.gameObject);
	                        inv.isPickedUp = false;
	                        //Debug.Log("ispickedup set to "+ inv.isPickedUp);
                        }
	                    //else, pickup failed
                        else
                        {
                        	Destroy(hit.transform.gameObject);
                        	inv.SpawnItem(item.prefab);
                            Debug.Log("Inventory full!");
                        }
                    }
	                //if you did not hit a pickupable object, check if you hit a storage device
                    else if(hit.transform.gameObject.GetComponent<Inven>() != null){
                    	if(hit.transform.gameObject.tag != "Player"){
	                    	Inven inv = hit.transform.gameObject.GetComponent<Inven>();
	                    	//enable the relevant UI element
	                    	inv.UIPlugger.gameObject.transform.GetChild(0).gameObject.SetActive(true);
	                    	storageInvOpen = true;
	                    	//force open the player's inventory
	                    	OpenInventory();
	                    	//Add distance check here
	                    	storageObjectPos = inv.gameObject.transform;
	                    	distanceGate = true;
                    	}
                    }
                }
            }
        }
	    if(distanceGate){
	    	DistanceCheck();
	    }
    }
}
