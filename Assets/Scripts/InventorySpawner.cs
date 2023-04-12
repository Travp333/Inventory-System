using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpawner : MonoBehaviour
{
	[SerializeField]
	GameObject UIPrefab;
    // Start is called before the first frame update
    void Start()
	{
		foreach(Inven i in GameObject.FindObjectsOfType<Inven>()){
			if(i.gameObject.tag != "Player"){
				GameObject g = Instantiate(UIPrefab, this.transform);
				//Debug.Log("Pluggin Ui Plugger");
				i.UIPlugger = g.gameObject;
				g.GetComponent<UiPlugger>().inven = i;
				g.name = i.gameObject.name + " Inventory";
				
				
			}
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
