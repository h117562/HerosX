using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[Serializable]
public class Player : MonoBehaviour
{
    public static Player I;

    private void Awake()
    {
        I = this;
    }
    
    ////////////////////싱글톤///////////////////////

    public PlayerInfo m_playerInfo;//현재 캐릭터 스탯
    public List<Item> m_items = new List<Item>();

    public ItemInfo m_item1;
    public ItemInfo m_item2;//테스트용 변수

    private void Start()
    {
        Item item = new Item();
        item.m_itemInfo = m_item1;//테스트용으로 아이템 두개 미리 넣기
        item.AddStack(1);

        Item item2 = new Item();
        item2.m_itemInfo = m_item2;
        item2.AddStack(1);

        m_items.Add(item);
        m_items.Add(item2);

    }

    public void AddItem(int count)//인벤토리에 아이템 추가
    {
    }
}
