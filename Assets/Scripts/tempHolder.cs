using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script handles the Swap mechanic in the inventory. it has a tempslot that we store inventory objects we are looking to swap in,
//and also handles the logic of doing the actual swap.
//written by Conor and Travis
public class tempHolder : MonoBehaviour
{
	[HideInInspector]
	public ItemStat slot = null;
	[HideInInspector]
	public int tempRow = -1, tempColumn = -1, tempCount = -1;
	[HideInInspector]
	public string tempName = null;
	Sprite tempImage = null;
	public Sprite emptyImage;
	Inven tempInven = null;
	UiPlugger tempPlug;
	Inven playerInven;
	private void Start()
	{
		ClearSlot();
		foreach(UiPlugger i in GameObject.FindObjectsOfType<UiPlugger>()){
			if(i.inven.gameObject.tag == "Player"){
				i.SpawnButtonsPlayer();
				playerInven = i.inven;
			}
			else{
				i.SpawnButtonsStorage();
			}
		}
	}
	public void ClearSlot(){
		foreach(UiPlugger i in GameObject.FindObjectsOfType<UiPlugger>()){
			if(i.inven == tempInven){
				i.ButtonDeselected(tempRow, tempColumn);
			}
		}
		slot = null;
		tempRow = -1;
		tempColumn = -1;
		tempCount = -1;
		tempName = null;
		tempImage = emptyImage;
		tempInven = null;
	}

	public void Swap(Inven inventoryObject, string coords) {
		//store a reference to the Ui script, as we will use it often
		UiPlugger plug = inventoryObject.UIPlugger.GetComponent<UiPlugger>();
		if(tempInven != null){
			tempPlug = tempInven.UIPlugger.GetComponent<UiPlugger>();
		}
		//parse the string into two ints, the string will be coordinates, structured like (1,2), which will then be parsed into 1 and 2. 
		string[] coords2 = coords.Split(",");
		int row = int.Parse(coords2[0]);
		int column = int.Parse(coords2[1]);
		// here, slot refers to the temporary slot in which you are holding an item you selected which you want to swap
		if (slot == null) {
			if(!Input.GetKey(KeyCode.LeftShift)){
				//find out what inventory slot the coordiantes you were passed points to, and store that data in the temp slot
				slot = inventoryObject.array[row,column];
				//if that data is named "", we know it is empty, and therefore we do not need to store it in the temp slot. 
				if(slot.Name != ""){
					//if the name is anything else, we know it is a valid inventory object, so we store its data in the temp slot as well as info needed for the UI
					tempRow = row; 
					tempColumn = column;
					tempName = slot.Name;
					tempImage = slot.image;
					tempCount = slot.Amount;
					tempInven = inventoryObject;
					//Debug.Log(slot.Name + " was selected");
					//This turns the button pressed darker, to indicate to the player that that inventory slot is being stored in the temp slot
					plug.ButtonSelected(row, column);	
				}
				else{
					//if the slot we picked is empty, we dont need to store any info on it and can jsut clear it out
					slot = null;
				}
			}
			else{
				for (int i = 0; i < inventoryObject.array[row, column].Amount; i++) {
					if(inventoryObject.array[row, column].Amount > 0){	
						//does the player inventory have space for this
						//if(){
						Debug.Log("TEST" + i);
						playerInven.SmartPickUp(inventoryObject.array[row, column]);
						if(playerInven.isPickedUp){
							inventoryObject.array[row, column].Amount = inventoryObject.array[row, column].Amount - 1;
							plug.UpdateItem(row, column, inventoryObject.array[row, column].Amount);
							if(inventoryObject.array[row, column].Amount <= 0){
								Debug.Log("DRY");
								inventoryObject.array[row, column].Name = "";
								inventoryObject.array[row, column].Amount = 0;
								inventoryObject.array[row, column].image = emptyImage;
								inventoryObject.array[row, column].full = false;
								plug.ChangeItem(row, column, emptyImage, 0, "");
							}
							playerInven.isPickedUp = false;
						}
						else{
							Debug.Log("Full Inventory");
						}
						//}
					}
					else{
						Debug.Log("Nothing here!");
					}
				}
			}
		}
		else if (slot != null) {
			//if the temp slot is not null, we know it is holding a valid inventory object. So, we must initiate the swap
			//if we are swapping two objects with the same name, prepare to stack!
			if(tempInven.array[tempRow, tempColumn].Name == inventoryObject.array[row, column].Name) {
				if(row == tempRow && tempColumn == column){
					//same name, same slot, same object, do nothing, reset
					//plug.ButtonDeselected(row, column);
					ClearSlot();
				}
				else{
					//two different slots, but same name. merge stacks
					//check if you can just call them and keep it under that item's stack size
					if((tempInven.array[tempRow, tempColumn].Amount + inventoryObject.array[row, column].Amount) > inventoryObject.array[row, column].StackSize){
						//we cant do that, set the second buttons count to the max and subtract the necessary amount from the furst button's amount
						tempInven.array[tempRow, tempColumn].Amount = ((inventoryObject.array[row, column].Amount + tempInven.array[tempRow, tempColumn].Amount) - inventoryObject.array[row, column].StackSize);
						tempPlug.UpdateItem(tempRow, tempColumn, tempInven.array[tempRow, tempColumn].Amount);
						inventoryObject.array[row, column].Amount = inventoryObject.array[row, column].StackSize;
						plug.UpdateItem(row, column, inventoryObject.array[row, column].Amount);
						ClearSlot();
						
					}
					else{
						//Debug.Log("Stacking two stacks of same item type");
						//we can simply add the temp slot and second button press together
						//add the items in temp slot to the second pressed button's slot, clear out original button's slot and temp slot
						inventoryObject.array[row, column].Amount = tempInven.array[tempRow, tempColumn].Amount + inventoryObject.array[row, column].Amount;
						plug.UpdateItem(row, column, inventoryObject.array[row, column].Amount);
						tempInven.array[tempRow, tempColumn].Name = "";
						tempInven.array[tempRow, tempColumn].Amount = 0;
						tempInven.array[tempRow, tempColumn].image = emptyImage;
						tempPlug.ChangeItem(tempRow,tempColumn, emptyImage, 0, "");
						ClearSlot();
					}
				}
			}
			else{
				//clean swap, two different objects
				//we find the inventory slot the tempslot object is pointing to, and set it equal to the second button's data
				tempInven.array[tempRow, tempColumn] = inventoryObject.array[row, column];
				//we then update the Ui to follow suit
				tempPlug.ChangeItem(tempRow, tempColumn, inventoryObject.array[row, column].image, inventoryObject.array[row, column].Amount, inventoryObject.array[row, column].Name);
				//then we set the second button equal to the temp slot's data
				inventoryObject.array[row, column] = slot;
				//we also have the Ui update
				plug.ChangeItem(row,column, tempImage, tempCount, tempName);
				ClearSlot();		
			}
		}
	}
}
