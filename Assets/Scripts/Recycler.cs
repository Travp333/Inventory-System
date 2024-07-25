using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
	[SerializeField]
	Inven input;
	[SerializeField]
	Inven output;
	int i3;
	public void startRecycle(){
		//iterate through full input inventory
		for (int i = 0; i < input.vSize; i++)
		{
			for (int i2 = 0; i2 < input.hSize; i2++)
			{
				if(input.array[i,i2].Objname == ""){
					//slot empty, move on!
					
				}
				else{
					//iterate through every item in that slot
					int count = input.array[i,i2].Amount;
					//Debug.Log("Recycling stack of " + count + " " + input.array[i,i2].Name);
					for (int i3 = 0; i3 < count; i3++) {		
						if(input.array[i,i2].prefab != null){
							if(input.array[i,i2].prefab.GetComponent<RecyclableItem>() != null){
								//Debug.Log("Recycled one "+ input.array[i,i2].Name);
								RecycleOneItemFromStackIntoInventory(i+", "+i2, output, input.array[i,i2].prefab.GetComponent<RecyclableItem>(), input);
							}
							else{
								Debug.Log("Not a recyclable object");
							}
						}
						else{
							Debug.Log("No prefab in slot!");
						}
					}
				}
			}
		}

	}
	public void RecycleOneItemFromStackIntoInventory(string coords, Inven output, RecyclableItem recyclableItem, Inven input){
		string [] coords2 = coords.Split(",");
		int row = int.Parse(coords2[0]);
		int column = int.Parse(coords2[1]);
		if(input.array[row, column].Objname != ""){
			if(input.array[row, column].prefab.GetComponent<RecyclableItem>()!= null){
				if(!((input.temp.tempRow == row)&&(input.temp.tempColumn == column))){
					//parsing incoming string into ints
					//This slot does in fact have an object in it
					if(input.array[row, column].Amount > 0){
						//make the button flash grey for a second to give feedback
						input.plug.ButtonPress(row, column);
						//Debug.Log("Recycling one " + array[row, column].Objname + " from slot (" + row + " , "+ column + " ) , now we have" + (array[row,column].Amount - 1));
						//deduct one of the items from the stack
						input.array[row, column].Amount = input.array[row, column].Amount - 1;
						//--------------------------------------------------------------------
						//CREATE RECYCLED ITEM
						
						recyclableItem = input.array[row, column].prefab.GetComponent<RecyclableItem>();
						foreach(Item i in recyclableItem.recyclesInto){
							for (int i2 = 0; i2 < recyclableItem.amount[i3]; i2++) {
								output.SmartPickUp(recyclableItem.recyclesInto[i3]);
								if(output.isPickedUp){
									//Debug.Log("Successfull pickup!");
									output.isPickedUp = false;
								}
								else{
									Debug.Log("No room in inventory, dropping on floor");
									output.SpawnItem(recyclableItem.recyclesInto[i3].prefab);
								}
							}
							i3++;
						}
						i3 = 0;
						
						//--------------------------------------------------------------------
						//you just dropped the last item in that slot, reverting to default
						if(input.array[row, column].Amount <= 0){
							//Debug.Log("Out of " + array[row, column].Objname + " in slot (" + row + " , "+ column + " ) , slot now empty ");
							input.NullInvenSlot(row, column);
							//updating UI to match new change
							input.plug.ClearSlot(row, column, input.temp.emptyImage);
						}
						else{
							//there are still more of that item in the slot, updating UI to match new change
							input.plug.UpdateItem(row, column, input.array[row,column].Amount);
						}
						return;
					}
				}
			}
		}
	}
	//Backup Methods in case of edge cases, like needing to recycle one individual object or a whole stack of objects still inside the players inventory (forced recycle mechanic?)
	public void RecycleOneItemFromStack(string coords, Inven output, Inven input, RecyclableItem recyclableItem){
		string [] coords2 = coords.Split(",");
		int row = int.Parse(coords2[0]);
		int column = int.Parse(coords2[1]);
		if(input.array[row, column].Objname != ""){
			if(input.array[row, column].prefab.GetComponent<RecyclableItem>()!= null){
				if(!((input.temp.tempRow == row)&&(input.temp.tempColumn == column))){
					//parsing incoming string into ints
					//This slot does in fact have an object in it
					if(input.array[row, column].Amount > 0){
						//make the button flash grey for a second to give feedback
						input.plug.ButtonPress(row, column);
						Debug.Log("Recycling one " + input.array[row, column].Objname + " from slot (" + row + " , "+ column + " ) , now we have" + (input.array[row,column].Amount - 1));
						//deduct one of the items from the stack
						input.array[row, column].Amount = input.array[row, column].Amount - 1;
						//--------------------------------------------------------------------
						//CREATE RECYCLED ITEM
						
						recyclableItem = input.array[row, column].prefab.GetComponent<RecyclableItem>();
						foreach(Item i in recyclableItem.recyclesInto){
							for (int i2 = 0; i2 < recyclableItem.amount[i3]; i2++) {
								output.SmartPickUp(recyclableItem.recyclesInto[i3]);
								if(output.isPickedUp){
									//Debug.Log("Successfull pickup!");
									output.isPickedUp = false;
								}
								else{
									Debug.Log("No room in inventory, dropping on floor");
									output.SpawnItem(recyclableItem.recyclesInto[i3].prefab);
								}
							}
							i3++;
						}
						i3 = 0;
						
						//--------------------------------------------------------------------
						//you just dropped the last item in that slot, reverting to default
						if(input.array[row, column].Amount <= 0){
							//Debug.Log("Out of " + array[row, column].Objname + " in slot (" + row + " , "+ column + " ) , slot now empty ");
							input.NullInvenSlot(row, column);
							//updating UI to match new change
							input.plug.ClearSlot(row, column, input.temp.emptyImage);
						}
						else{
							//there are still more of that item in the slot, updating UI to match new change
							input.plug.UpdateItem(row, column, input.array[row,column].Amount);
						}
						return;
					}
				}
			}
		}
	}
	public void RecycleEntireStack(string coords, Inven output, Inven input, RecyclableItem recyclableItem){
		string [] coords2 = coords.Split(",");
		int row = int.Parse(coords2[0]);
		int column = int.Parse(coords2[1]);
		if(input.array[row, column].Objname != ""){
			if(input.array[row, column].prefab.GetComponent<RecyclableItem>()!= null){
				if(!((input.temp.tempRow == row)&&(input.temp.tempColumn == column))){
					//parsing incoming string into ints
					//This slot does in fact have an object in it
					//make the button flash grey for a second to give feedback
					input.plug.ButtonPress(row, column);
					//Debug.Log("Recycling all " + array[row, column].Objname + " in slot (" + row + " , "+ column + " ) , now we have 0 ");
					//deduct one of the items from the stack
					
					//--------------------------------------------------------------------
					//CREATE RECYCLED ITEM
					
					recyclableItem = input.array[row, column].prefab.GetComponent<RecyclableItem>();
					for (int i4 = 0; i4 < input.array[row, column].Amount; i4++)
					{
						foreach(Item i in recyclableItem.recyclesInto){
							for (int i2 = 0; i2 < recyclableItem.amount[i3]; i2++) {
								output.SmartPickUp(recyclableItem.recyclesInto[i3]);
								if(output.isPickedUp){
									//Debug.Log("Successfull pickup!");
									output.isPickedUp = false;
								}
								else{
									//Debug.Log("No room in inventory, dropping on floor");
									output.SpawnItem(recyclableItem.recyclesInto[i3].prefab);
								}
							}
							i3++;
						}
						i3 = 0;
					}
					input.array[row, column].Amount = 0;
					
					//--------------------------------------------------------------------
					//you just dropped the last item in that slot, reverting to default
					
					//Debug.Log("Out of " + array[row, column].Objname + " in slot (" + row + " , "+ column + " ) , slot now empty ");
					input.NullInvenSlot(row, column);
					//updating UI to match new change
					input.plug.ClearSlot(row, column, input.temp.emptyImage);
					return;
					
				}
			}
		}
	}
}
