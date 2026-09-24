using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public static Hotbar instance;

    [SerializeField] private List<ItemData> slots = new List<ItemData>();
    [SerializeField] private List<Image> Icons = new List<Image>();
    [SerializeField] private int MaxSlot = 2;
    [SerializeField] private int CurrentSlot = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // スロットの初期化
        instance = this;
        for (int i = 0; i < MaxSlot; i++)
        {
            slots.Add(null);
        }
    }

    public void AddItem(ItemData item)
    {
        for (int i = 0; i < MaxSlot; i++)
        {
            // スロットが空なら入手
            if (slots[i] == null)
            {
                slots[i] = item;
                Icons[i].sprite = item.Icon();
                Icons[i].enabled = true;
                return;
            }
        }
        Debug.Log("持ち物がいっぱいです");
    }

    public void UseItem()
    {
        ItemData item = slots[CurrentSlot];
        if(item == null)
        {
            return;
        }
        /*
    switch(item.type)
        {

        }

        */
  }
}
