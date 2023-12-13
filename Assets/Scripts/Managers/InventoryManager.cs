using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryManager : MonoBehaviour
{
    [Header("Equipped Items")]
    public ItemInfo[] m_EquipMents = new ItemInfo[4];

    [Header("Inventory")]
    public List<Item> m_Items = new List<Item>();

    private void Start()
    {

    }

    public void AddItem(ref ItemInfo info, int count)//�κ��丮�� ������ �߰�
    {
        if (info != null)
        {
            if (CheckFullStack(ref info))//�κ��丮���� ���ð����� �������� �ִ��� ã��
            {
                foreach (Item item in m_Items)
                {
                    if (item.m_itemInfo.Equals(info))//�κ��丮���� ������ ��� �ִ°��
                    {
                        item.AddStack(count);
                    }
                }
            }
            else//���ð����� �������� ���� ��� ���� ����Ʈ�� �߰�
            {
                Item newitem = new Item();
                newitem.m_itemInfo = info;
                newitem.AddStack(count);

                m_Items.Add(newitem);
            }
        }

        for (int i = 0; i < m_Items.Count; i++)
        {
            if (m_Items[i].m_itemStack == 0)//������ ���� �������� ���� ��� ����Ʈ���� ����
            {
                m_Items.RemoveAt(i);
            }
        }

    }

    public bool SwapEquip(int index)//��� ���� (�κ��丮�� ��� ��Ŭ�� ���� ��� ȣ��)
    {
        if (m_Items.Count > index)//��ĭ Ŭ�� Ȯ��
        {
            ItemInfo info = m_Items[index].m_itemInfo;

            switch (info.m_Type)
            {
                case ItemType.Weapon://������ ���

                    if (m_EquipMents[0] == null)
                    {
                        m_EquipMents[0] = info;
                        AddItem(ref info, -1);//�����Ϸ��� ����� ���� ����
                    }
                    else
                    {
                        AddItem(ref m_EquipMents[0], 1);//���� �ִ� ���� �κ��丮��
                        m_EquipMents[0] = info;
                        AddItem(ref info, -1);//�����Ϸ��� ����� ���� ����
                    }
                    break;
                case ItemType.Armor://������ ���
                    if (m_EquipMents[1] == null)
                    {
                        m_EquipMents[1] = info;
                        AddItem(ref info, -1);//�����Ϸ��� ����� ���� ����
                    }
                    else
                    {
                        AddItem(ref m_EquipMents[1], 1);//���� �ִ� ���� �κ��丮��
                        m_EquipMents[1] = info;
                        AddItem(ref info, -1);//�����Ϸ��� ����� ���� ����
                    }
                    break;
                default://���� �Ұ����� ����� ��� false ����
                    Debug.Log("���� �Ұ����մϴ�");//�׽�Ʈ
                    return false;
            }
        }

        return true;
    }

    public void Unequip(int index)//��� ���� (����â�� ��� ��Ŭ�� ���� ��� ȣ��)
    {
        if (m_EquipMents[index] != null)
        {
            AddItem(ref m_EquipMents[index], 1);
            m_EquipMents[index] = null;
        }

    }

    public Item GetItem(int index)//�κ��丮�� ������ �����͸� �������� �Լ�
    {
        if (m_Items.Count > index)//��ĭ Ŭ�� Ȯ��
        {
           return m_Items[index];
        }

        return null;
    }

    public int GetDamage()//������ ����� ������ �������� �Լ�
    {
        if (m_EquipMents[0] == null) 
        {
            return 0;
        }

        return m_EquipMents[0].m_Damage;
    }

    public int GetDefense()//������ ����� ������ �������� �Լ�
    {
        if (m_EquipMents[1] == null)
        {
            return 0;
        }

        return m_EquipMents[1].m_Defense;
    }

    private bool CheckFullStack(ref ItemInfo info)//�������� �ִ� �������� üũ�ϴ� �Լ� +�ִ� ������ ��� ����Ʈ�� ���� �߰�
    {
        foreach (Item item in m_Items)
        {
            if (item.m_itemInfo.Equals(info))
            {
                if (item.m_itemStack < 50) //��� �������� 50���� �ִ���
                {
                    return true;
                }
            }
        }

        return false;//�κ��丮�� �߰��Ϸ��� �������� ���� ���, ��� �ִ� ������ ��� false ����
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")//��ӵ� �������� ��� Item �±׸� ���� ����
        {
            Item item = other.GetComponent<DroppedItem>().m_item;//�浹�� ��ü�� ������ ������ ������

            AddItem(ref item.m_itemInfo, item.m_itemStack);//�κ��丮�� ���ð�����ŭ �߰�

            other.GetComponent<DroppedItem>().DestoryItem();//��ü ����
        }
    }
}
