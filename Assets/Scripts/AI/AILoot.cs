using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILoot : MonoBehaviour
{
    [SerializeField]private LootTable lootTable;
    public LootTable LootTable{
        get{
            return lootTable;
        }set{
            lootTable = value;
        }
    }
    
}
