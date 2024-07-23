using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
	[SerializeField]
	Inven input;
	[SerializeField]
	Inven output;
	public void startRecycle(){
		//iterate through full input inventory
		for (int i = 0; i < input.vSize; i++)
		{
			for (int i2 = 0; i2 < input.hSize; i2++)
			{
				if(input.array[i,i2].Name == ""){
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
								input.RecycleOneItemFromStackIntoInventory(i+", "+i2, output);
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
}
