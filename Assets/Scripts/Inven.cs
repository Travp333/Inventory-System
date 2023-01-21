using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemStat {

    public string Name = "Empty";
    public float Weight = 0;
    public int Amount = 0;
    public int StackSize = 0;
    public GameObject prefab = null;
}
public class Inven : MonoBehaviour
{
    [SerializeField]
    public int hSize = 4;
    [SerializeField]
    public int vSize = 4;
    public bool isPickedUp = false;
    [HideInInspector]
    public Item item;
    public ItemStat [,] array;
    // Start is called before the first frame update

    void Start()
    {
        array = new ItemStat[hSize,vSize];
        for (int i = 0; i < hSize; i++)
        {
            for (int i2 = 0; i2 < vSize; i2++)
            {
                array[i,i2] = new ItemStat();
            }
        }
        //ItemStat rand;
        //int new3 = Random.Range(0,3);
        //int new2 = Random.Range(0,3);
        //rand = array[new3, new2];
        //rand.Name = item.Objname;
        //rand.Amount = rand.Amount + 1;
        ///rand.Weight = item.weight * rand.Amount;
        //rand.StackSize = item.stackSize;
        //Debug.Log(new3 + " , " + new2);
        //Debug.Log(rand.Name);
       // Debug.Log(rand.Weight);
        //Debug.Log(rand.Amount);
        //Debug.Log(rand.StackSize);
    }
    public void PickUp(Item item){
        //iterating through colomns
        for (int i = 0; i < hSize; i++)
        {
            Debug.Log("Column " + i);
            //iterating through rows
            for (int i2 = 0; i2 < vSize; i2++)
            {
                Debug.Log("Row" + i2);
                //is this slot empty?
                if(array[i,i2].Name == "Empty"){
                    //yes empty, filling slot
                    Debug.Log("Slot (" + i + " , "+ i2 + " ) is empty, putting " + item.Objname + " in slot");
                    isPickedUp = true;
                    array[i,i2].Name = item.Objname;
                    array[i,i2].Weight = item.weight;
                    array[i,i2].Amount = array[i,i2].Amount + 1;
                    array[i,i2].StackSize = item.stackSize;
                    array[i,i2].prefab = item.prefab;
                    i=0;
                    i2=0;
                    return;

                }
                //no theres something here
                else{
                    Debug.Log("Slot (" + i + " , " + i2 + " ) has " + array[i,i2].Amount + " " + array[i,i2].Name + " in it, checking if it matches the new " + item.Objname);
                    //basically is there room for it, is it the same object
                    if(array[i,i2].Name == item.Objname && array[i,i2].StackSize !>= array[i,i2].Amount + 1){
                        Debug.Log("Slot (" + i + " , "+ i2 + " ) has room, adding " + item.Objname + " to stack");
                        //same object, room in the stack, adding to stack
                        isPickedUp = true;
                        array[i,i2].Amount = array[i,i2].Amount + 1;
                        Debug.Log("we now have " + array[i,i2].Amount + " "+ array[i,i2].Name + " in " + "Slot (" + i + " , "+ i2 + " ) ");
                        i=0;
                        i2=0;
                        return;
                    }
                    else if(array[i,i2].StackSize <= array[i,i2].Amount + 1){
                        Debug.Log("cant hold more than " + array[i,i2].Amount + " " + array[i,i2].Name + " in one stack, starting new stack... ");
                    }
                    //otherwise theres something here but itsnot the same type or theres no room for it
                }
            }
        }
    }
    public void DropItem(){
        //iterating through columns
        for (int i = 0; i < hSize; i++)
        {
            //iterating through rows
            for (int i2 = 0; i2 < vSize; i2++)
            {
                if(array[i,i2].Amount > 0){
                    Debug.Log("Dropping one " + array[i,i2].Name + " from slot (" + i + " , "+ i2 + " ) , now we have" + (array[i,i2].Amount - 1));
                    array[i,i2].Amount = array[i,i2].Amount - 1;
                    Instantiate(array[i,i2].prefab, this.transform.root.transform.position, Quaternion.identity);
                    if(array[i,i2].Amount <= 0){
                        Debug.Log("Out of " + array[i,i2].Name + " in slot (" + i + " , "+ i2 + " ) , slot now empty ");
                        array[i,i2].Name = "Empty";
                        array[i,i2].Weight = 0;
                        array[i,i2].Amount = 0;
                        array[i,i2].StackSize = 0;
                        array[i,i2].prefab = null;
                    }
                    return;
                }
            }
        }
    }

}
