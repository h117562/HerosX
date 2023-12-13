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
    
    ////////////////////�̱���///////////////////////

    public PlayerInfo m_playerInfo;//���� ĳ���� ����
    public List<Item> m_items = new List<Item>();

    public ItemInfo m_item1;
    public ItemInfo m_item2;//�׽�Ʈ�� ����

    private void Start()
    {
        Item item = new Item();
        item.m_itemInfo = m_item1;//�׽�Ʈ������ ������ �ΰ� �̸� �ֱ�
        item.AddStack(1);

        Item item2 = new Item();
        item2.m_itemInfo = m_item2;
        item2.AddStack(1);

        m_items.Add(item);
        m_items.Add(item2);

    }

    public void AddItem(int count)//�κ��丮�� ������ �߰�
    {
    }
}
