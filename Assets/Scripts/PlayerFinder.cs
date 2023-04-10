using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script creates a reference to the player object and calls methods on it. 
//This was a workaround to allow calling methods with arguments through the unity event system.
//Written by Travis
public class PlayerFinder : MonoBehaviour
{
	[SerializeField] Inven inven;
	GameObject player;
	public void SendDropItem(){
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		if(player.GetComponent<Inven>() != null){
			player.GetComponent<Inven>().DropSpecificItem(this.gameObject.transform.parent.name);
		}
		
	}
	public void SendSwap() {
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		if (player.GetComponent<Inven>() != null && player.GetComponent<tempHolder>() != null)
		{
			//player.GetComponent<Inven>().DropSpecificItem(this.gameObject.transform.parent.name);
			tempHolder tH = player.GetComponent<tempHolder>();
			tH.Swap(player.GetComponent<Inven>(), this.gameObject.transform.parent.name);
		}
	}
}
