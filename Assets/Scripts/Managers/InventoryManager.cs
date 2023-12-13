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

    public void AddItem(ref ItemInfo info, int count)//인벤토리에 아이템 추가
    {
        if (info != null)
        {
            if (CheckFullStack(ref info))//인벤토리내에 스택가능한 아이템이 있는지 찾기
            {
                foreach (Item item in m_Items)
                {
                    if (item.m_itemInfo.Equals(info))//인벤토리내에 동일한 장비가 있는경우
                    {
                        item.AddStack(count);
                    }
                }
            }
            else//스택가능한 아이템이 없을 경우 새로 리스트에 추가
            {
                Item newitem = new Item();
                newitem.m_itemInfo = info;
                newitem.AddStack(count);

                m_Items.Add(newitem);
            }
        }

        for (int i = 0; i < m_Items.Count; i++)
        {
            if (m_Items[i].m_itemStack == 0)//개수가 없는 아이템이 있을 경우 리스트에서 삭제
            {
                m_Items.RemoveAt(i);
            }
        }

    }

    public bool SwapEquip(int index)//장비 장착 (인벤토리의 장비를 우클릭 했을 경우 호출)
    {
        if (m_Items.Count > index)//빈칸 클릭 확인
        {
            ItemInfo info = m_Items[index].m_itemInfo;

            switch (info.m_Type)
            {
                case ItemType.Weapon://무기일 경우

                    if (m_EquipMents[0] == null)
                    {
                        m_EquipMents[0] = info;
                        AddItem(ref info, -1);//착용하려는 장비의 개수 감소
                    }
                    else
                    {
                        AddItem(ref m_EquipMents[0], 1);//끼고 있던 장비는 인벤토리로
                        m_EquipMents[0] = info;
                        AddItem(ref info, -1);//착용하려는 장비의 개수 감소
                    }
                    break;
                case ItemType.Armor://갑옷일 경우
                    if (m_EquipMents[1] == null)
                    {
                        m_EquipMents[1] = info;
                        AddItem(ref info, -1);//착용하려는 장비의 개수 감소
                    }
                    else
                    {
                        AddItem(ref m_EquipMents[1], 1);//끼고 있던 장비는 인벤토리로
                        m_EquipMents[1] = info;
                        AddItem(ref info, -1);//착용하려는 장비의 개수 감소
                    }
                    break;
                default://착용 불가능한 장비일 경우 false 리턴
                    Debug.Log("장착 불가능합니다");//테스트
                    return false;
            }
        }

        return true;
    }

    public void Unequip(int index)//장비 해제 (상태창의 장비를 우클릭 했을 경우 호출)
    {
        if (m_EquipMents[index] != null)
        {
            AddItem(ref m_EquipMents[index], 1);
            m_EquipMents[index] = null;
        }

    }

    public Item GetItem(int index)//인벤토리내 아이템 데이터를 가져오는 함수
    {
        if (m_Items.Count > index)//빈칸 클릭 확인
        {
           return m_Items[index];
        }

        return null;
    }

    public int GetDamage()//착용한 장비의 스탯을 내보내는 함수
    {
        if (m_EquipMents[0] == null) 
        {
            return 0;
        }

        return m_EquipMents[0].m_Damage;
    }

    public int GetDefense()//착용한 장비의 스탯을 내보내는 함수
    {
        if (m_EquipMents[1] == null)
        {
            return 0;
        }

        return m_EquipMents[1].m_Defense;
    }

    private bool CheckFullStack(ref ItemInfo info)//아이템이 최대 스택인지 체크하는 함수 +최대 스택일 경우 리스트에 새로 추가
    {
        foreach (Item item in m_Items)
        {
            if (item.m_itemInfo.Equals(info))
            {
                if (item.m_itemStack < 50) //모든 아이템은 50개가 최대임
                {
                    return true;
                }
            }
        }

        return false;//인벤토리에 추가하려는 아이템이 없을 경우, 모두 최대 스택일 경우 false 리턴
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")//드롭된 아이템은 모두 Item 태그를 갖고 있음
        {
            Item item = other.GetComponent<DroppedItem>().m_item;//충돌된 물체의 아이템 정보를 가져옴

            AddItem(ref item.m_itemInfo, item.m_itemStack);//인벤토리에 스택갯수만큼 추가

            other.GetComponent<DroppedItem>().DestoryItem();//객체 삭제
        }
    }
}
