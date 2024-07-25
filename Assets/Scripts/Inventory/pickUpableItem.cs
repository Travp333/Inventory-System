using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpableItem : MonoBehaviour
// This has become too specific to coins, need to make more generic!
{
    [SerializeField]
    public Item item;
    [SerializeField]
    public int count = 1;
    [SerializeField]
    GameObject coin2, coin3, coin4, coin5, coin6, coin7, coin8, coin9, coinRoll;

    public void EditCount(int count2){
        count = count2;
        if(count == 1){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(false);
            coin3.SetActive(false);
            coin4.SetActive(false);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 2){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(false);
            coin4.SetActive(false);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 3){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(false);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 4){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 5){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 6){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 7){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
            coin7.SetActive(true);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }
        else if(count == 8){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
            coin7.SetActive(true);
            coin8.SetActive(true);
            coin9.SetActive(false);
        }
        else if(count == 9){
            this.GetComponent<MeshRenderer>().enabled = true;
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
            coin7.SetActive(true);
            coin8.SetActive(true);
            coin9.SetActive(true);
        }
        else if(count >= 10){
            this.GetComponent<MeshRenderer>().enabled = false;
            coinRoll.SetActive(true);
            coin2.SetActive(false);
            coin3.SetActive(false);
            coin4.SetActive(false);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);
            coin9.SetActive(false);
        }

    }
}
