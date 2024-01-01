using System;
using System.Collections;
using System.Collections.Generic;
using GD;
using My_Assets.Scripts;
using My_Assets.Scripts.Managers;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    private MultiLingualData multiLingualData;
    
    [SerializeField]
    private MultiLanguageGameEvent removeItemFromInventory;

    public MultiLingualData MultiLingualData
    {
        set => multiLingualData = value;
    }

    public void RemoveItem()
    {
        removeItemFromInventory.Raise(multiLingualData);
        Destroy(gameObject);
    }
}
