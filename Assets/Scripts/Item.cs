using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    public string Objname;
    [SerializeField]
    public int weight;
    [SerializeField]
    public int stackSize;
    [SerializeField]
    public Texture img;

}
