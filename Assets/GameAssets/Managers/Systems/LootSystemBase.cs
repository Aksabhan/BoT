using UnityEngine;
using UnityEngine.InputSystem;

public class LootSystemBase : MonoBehaviour
{
    public SO_LootTableDemo table;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame) {
           SO_Lootable_Items temp =  GenerateLoot(table);
            Debug.Log($"W00t!!! You looted a {temp.itemName}!");
        }
    }

    private SO_Lootable_Items GenerateLoot(SO_LootTableDemo table) {
        int randomValue = Random.Range(0, table.totalValue+1);//in int, second value is exclusive...
        Debug.Log($"The random loot value is {randomValue}");
        for (int i = 0;i<table.items.Count; i++) {
            if(randomValue <= table.items[i].rarity) {
                return table.items[i];
            }
            else {
                randomValue -= table.items[i].rarity;
            }
        }
        return null; //Should only happen if the table is REALLY broken
    }
}
    

