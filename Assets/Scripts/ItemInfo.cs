using System;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Etc_Item,
    Usable_Item,
}


[CreateAssetMenu(fileName = "DefaultItemInfo", menuName = "TopDownController/ItemInfo/Default", order = 0)]
public class ItemInfo : ScriptableObject
{
    public ItemType Type;//������ ����
    public int m_itemId;//������ �ڵ�
    public string m_name;//�̸�
    public string m_description;//����
    public int m_damage;//�����Ǵ� ���ݷ�
    public int m_defense;//�����Ǵ� ����
    public float m_attackSpeed;//�����Ǵ� ���ݼӵ�
    public float m_movementSpeed;//�����Ǵ� �̵��ӵ�
    public Sprite m_Image;//������ �̹���
}
