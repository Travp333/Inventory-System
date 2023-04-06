using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
	GameObject player;
	public void SendDropItem(){
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		if(player.GetComponent<Inven>() != null){
			Debug.Log(this.gameObject.transform.parent.name);
			player.GetComponent<Inven>().DropSpecificItem(this.gameObject.transform.parent.name);
		}
		
	}
}
