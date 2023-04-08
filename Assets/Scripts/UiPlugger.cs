using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiPlugger : MonoBehaviour
{
    [SerializeField]
    public GameObject[] slots;
    UIReferenceHolder reff;
    int i = 0;
    [SerializeField]
    public Sprite empty;
    
    public void ChangeItem(int row, int column, Sprite img, int count, string name){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().sprite = img;
                reff.text.GetComponent<TextMeshProUGUI>().text = name;
                reff.count.GetComponent<TextMeshProUGUI>().text = "x"+count;
            }
            i++;
        }
        i = 0;
    }
    public void UpdateItem(int row, int column, int count){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.count.GetComponent<TextMeshProUGUI>().text = "x"+count;
            }
            i++;
        }
        i = 0;
    }
    public void ClearSlot(int row, int column){
        foreach(GameObject g in slots){
            if(slots[i].name == row+","+column){
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().sprite = empty;
                reff.text.GetComponent<TextMeshProUGUI>().text = "";
                reff.count.GetComponent<TextMeshProUGUI>().text = "x0";
            }
            i++;
        }
        i = 0;
    }
    public void ButtonSelected(int row, int column) {
        foreach (GameObject g in slots)
        {
            if (slots[i].name == row + "," + column)
            {
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().color *= .5f;
            }
            i++;
        }
        i = 0;
    }
    public void ButtonDeselected(int row, int column)
    {
        foreach (GameObject g in slots)
        {
            if (slots[i].name == row + "," + column)
            {
                reff = slots[i].GetComponent<UIReferenceHolder>();
                reff.button.GetComponent<UnityEngine.UI.Image>().color *= 2f;
            }
            i++;
        }
        i = 0;
    }

}
