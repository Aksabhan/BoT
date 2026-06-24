using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_LootTableDemo", menuName = "Scriptable Objects/SO_LootTableDemo")]
public class SO_LootTableDemo : ScriptableObject
{
    public List<SO_Lootable_Items> items;
    [HideInInspector]
    public int totalValue;

    private void OnEnable() {
        //Should order table!
        //Calculate the table total Value
        foreach(SO_Lootable_Items i in items) {
            totalValue += i.rarity;
        }
        Debug.Log($"{this.name} has a total value of {totalValue}");
    }

    private void OnDisable() {
        totalValue = 0;
    }
}
