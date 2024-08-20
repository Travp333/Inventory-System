using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackModelManager : MonoBehaviour
{
    [SerializeField]
    public float mergeDistance;
    //basically just store a list of all pickupable items and check their distances on fixedUpdate or on a delayed update or somn idk
    [SerializeField]
    public List<GameObject> possibleMergeList = new List<GameObject>();
    // Start is called before the first frame update

    public void AddToList(GameObject g){
        possibleMergeList.Add(g);
        foreach(GameObject m in possibleMergeList){
            if(Vector3.Distance(m.transform.position, g.transform.position) < mergeDistance){
                //something here to like delete the other thing and remove it from the list????
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
