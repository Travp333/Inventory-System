using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem 
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;
    public InventorySystem(int size) 
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++) {
            inventorySlots.Add(new InventorySlot());
        }
    }

    //I think there is a problem here, only the second two cases ever work the first case never goes off, so items of the same type do not stack. I think the issue is 
    //with ContainsItem - trav

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd) {
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        {
            Debug.Log("does this ever fire?");
            foreach (var slot in invSlot) {
                if (slot.RoomLeftInStack(amountToAdd)) {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
            
        }
        else if (HasFreeSlot(out InventorySlot freeSlot)) {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    //this may be causeing issues above, and i dont understand it well enough to go super hard on this. i at least know itemToAdd is being passed properly,
    //it properly identifies the objects but it seems like it always returns false - trav

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot) {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();

        //Debug.Log(itemToAdd);

        return invSlot == null ? true : false;
    }

    //i think this is working properly since the second case in AddToInventory works - trav

    public bool HasFreeSlot(out InventorySlot freeSlot) {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
