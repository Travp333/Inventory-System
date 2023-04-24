using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script creates a reference to the storage object and calls methods on it. 
//This was a workaround to allow calling methods with arguments through the unity event system.
//Written by Travis
public class StorageFinder : MonoBehaviour
{
	public GameObject storage;
	GameObject player;
	void Start()
	{
		storage = this.transform.parent.parent.parent.GetComponent<UiPlugger>().inven.gameObject;
	}
	public void SendDropItem(){
		if(storage.GetComponent<Inven>() != null){
			storage.GetComponent<Inven>().DropSpecificItem(this.gameObject.transform.parent.name);
		}
		
	}
	public void SendSwap() {
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		if (storage.GetComponent<Inven>() != null && player.GetComponent<tempHolder>() != null)
		{
			//player.GetComponent<Inven>().DropSpecificItem(this.gameObject.transform.parent.name);
			tempHolder tH = player.GetComponent<tempHolder>();
			tH.Swap(storage.GetComponent<Inven>(), this.gameObject.transform.parent.name);
		}
	}
	public void tryRecycle(){
		
	}
}
