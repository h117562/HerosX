using System;
using UnityEngine;


[Serializable]
public class Item
{
    [Range(0, 50)] public int m_itemStack = 0;//½ºÅÃ °¹¼ö
    public ItemInfo m_itemInfo;

    public void AddStack(int count)
    {
        m_itemStack += count;
    }
}
