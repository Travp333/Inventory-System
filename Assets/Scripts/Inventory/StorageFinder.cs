using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script creates a reference to the storage object and calls methods on it. 
//This was a workaround to allow calling methods with arguments through the unity event system.
//Written by Travis
public class StorageFinder : MonoBehaviour
{
	public GameObject storage;
	public Inven storageInven;
	GameObject player;
	tempHolder tH;
	void Start()
	{
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		if(this.transform.parent.parent.parent.GetComponent<UiPlugger>() != null){
			storage = this.transform.parent.parent.parent.GetComponent<UiPlugger>().inven.gameObject;
		}
		if(storage.GetComponent<Inven>() != null){
			storageInven = storage.GetComponent<Inven>();
		}
		if(player.GetComponent<tempHolder>() != null){
			tH = player.GetComponent<tempHolder>();
		}
		
	}
	public void SendDropItem(){
		storageInven.DropSpecificItem(this.gameObject.transform.parent.name);
	}
	public void SendDropAllItems(){
		storageInven.DropWholeStack(this.gameObject.transform.parent.name);
	}
	public void SendSwap() {	 
		tH.Swap(storage.GetComponent<Inven>(), this.gameObject.transform.parent.name);
	}
	public void SendPickUp(){
		tH.HoldItem(storage.GetComponent<Inven>(), this.gameObject.transform.parent.name);
	}
	public void SendReleaseItem(){
		tH.DropItem(storage.GetComponent<Inven>(), this.gameObject.transform.parent.name);
	}
	public void tryRecycle(){
		storageInven.RecycleOneItemFromStack(this.gameObject.transform.parent.name);
	}
	public void tryRecycleAll(){
		storageInven.RecycleEntireStack(this.gameObject.transform.parent.name);
	}
}
