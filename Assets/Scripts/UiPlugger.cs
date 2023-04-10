﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//This script ensures the Inventories UI changes alongside the backend. There are various methods here to change the name, image, and count of inventory slots.
//Written by Conor and Travis
public class UiPlugger : MonoBehaviour
{
    [SerializeField]
    public GameObject[] slots;
    UIReferenceHolder reff;
    int i = 0;
    [SerializeField]
	//public Sprite empty;
	//This is used when all of the information about an inventoyr obejct is new
    public void ChangeItem(int row, int column, Sprite img, int count, string name){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().sprite = img;
                reff.text.GetComponent<TextMeshProUGUI>().text = name;
                reff.count.GetComponent<TextMeshProUGUI>().text = "x"+count;
            }
            i++;
        }
        i = 0;
    }
	//this is used when simply changing the amount of an inventory object.
    public void UpdateItem(int row, int column, int count){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.count.GetComponent<TextMeshProUGUI>().text = "x"+count;
            }
            i++;
        }
        i = 0;
    }
	//this is used when clearing all data from a slot
	public void ClearSlot(int row, int column, Sprite emp){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
	            reff.button.GetComponent<UnityEngine.UI.Image>().sprite = emp;
                reff.text.GetComponent<TextMeshProUGUI>().text = "";
                reff.count.GetComponent<TextMeshProUGUI>().text = "x0";
            }
            i++;
        }
        i = 0;
    }
	//This is called to give feedback to the player when they simply press a button, ie dropping an object
	public void ButtonPress(int row, int column){
		ButtonSelected(row, column);
		StartCoroutine(ExecuteAfterTime(.05f, row, column));
	}
	//this allows me to execute code after a delay
	IEnumerator ExecuteAfterTime(float time, int row, int column)
	{
		 yield return new WaitForSeconds(time);
		 ButtonDeselected(row, column);
		 // Code to execute after the delay
	}
	//this is to give feedback for when a button has been selected, ie it has been stored in a temp slot preparing for a swap
	public void ButtonSelected(int row, int column) {
		Debug.Log("Made it into button selected");
        foreach (GameObject g in slots)
        {
            if (slots[i].name == row + "," + column)
            {
            	Debug.Log("Made it past the for loop");
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().color *= .5f;
            }
            i++;
        }
        i = 0;
    }
	//this is for when a button has been deselected, ie it has just finished swapping and needs to return to normal state
    public void ButtonDeselected(int row, int column)
    {
        foreach (GameObject g in slots)
        {
            if (slots[i].name == row + "," + column)
            {
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().color *= 2f;
            }
            i++;
        }
        i = 0;
    }

}
