using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHolder : MonoBehaviour
{

    ItemStat slot = null;
	int tempRow, tempColumn, tempCount = -1;
	string tempName = null;
	Sprite tempImage = null;
	

	private void Awake()
	{
		slot = null;
	}
	public void Swap(Inven inventoryObject, string coords) {
		string[] coords2 = coords.Split(",");
		int row = int.Parse(coords2[0]);
		int column = int.Parse(coords2[1]);
		
		if (slot == null) {
			slot = inventoryObject.array[row,column];

			tempRow = row; 
			tempColumn = column;
			tempName = slot.Name;
			tempImage = slot.image;
			tempCount = slot.Amount;

			Debug.Log(slot.Name);
			inventoryObject.UIPlugger.GetComponent<UiPlugger>().ButtonSelected(row, column);
		}
		else if (slot != null) {
			inventoryObject.array[tempRow, tempColumn] = inventoryObject.array[row, column];
			inventoryObject.UIPlugger.GetComponent<UiPlugger>().ChangeItem(tempRow, tempColumn, inventoryObject.array[row, column].image, inventoryObject.array[row, column].Amount, inventoryObject.array[row, column].Name);

			inventoryObject.array[row, column] = slot;
			inventoryObject.UIPlugger.GetComponent<UiPlugger>().ChangeItem(row,column, tempImage, tempCount, tempName);
			inventoryObject.UIPlugger.GetComponent<UiPlugger>().ButtonDeselected(tempRow, tempColumn);
			slot = null;
			tempRow = -1;
			tempColumn = -1;
			tempCount = -1;
			tempName = null;
			tempImage = inventoryObject.UIPlugger.GetComponent<UiPlugger>().empty;
		}
			
		

	}
}
