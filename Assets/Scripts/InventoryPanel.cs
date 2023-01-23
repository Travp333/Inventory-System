using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    Inven inv = null;
	Vector2Int dim;

	private void Start()
	{
		if (inv != null) {
			dim = new Vector2Int(inv.hSize, inv.vSize);
		}
		for (int i = 0; i < dim.x; i++)
		{
			for (int j = 0; j < dim.y; j++) { 
				//add buttons to inventory panel
			}
		}
	}
}
