using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    public string Objname;
    [SerializeField]
    public float weight;
    [SerializeField]
    public int stackSize;
    [SerializeField]
    public Sprite img;
    [SerializeField]
    public GameObject prefab;

}
