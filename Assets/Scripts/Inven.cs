using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemStat {

    public string Name { get; set; }
    public int Weight { get; set; }
    public int Amount { get; set; }
    public int StackSize { get; set; }
}
public class Inven : MonoBehaviour
{
    [SerializeField]
    public Item item;
    ItemStat [,] array;
    // Start is called before the first frame update
    void Start()
    {
        ItemStat rand;
        array = new ItemStat[4,4];

        for (int i = 0; i < 4; i++)
        {
            for (int i2 = 0; i2 < 4; i2++)
            {
                array[i,i2] = new ItemStat();
            }
        }
        int new3 = Random.Range(0,3);
        int new2 = Random.Range(0,3);
        rand = array[new3, new2];

        rand.Name = item.Objname;
        rand.Amount = rand.Amount + 1;
        rand.Weight = item.weight * rand.Amount;
        rand.StackSize = item.stackSize;
        Debug.Log(new3 + " , " + new2);
        Debug.Log(rand.Name);
        Debug.Log(rand.Weight);
        Debug.Log(rand.Amount);
        Debug.Log(rand.StackSize);


    }

}
