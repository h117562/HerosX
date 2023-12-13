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
    public ItemType m_Type;//������ ����
    public int m_ItemId;//������ �ڵ�
    public string m_ItemName;//�̸�
    public string m_Description;//����
    public int m_Damage;//�����Ǵ� ���ݷ�
    public int m_Defense;//�����Ǵ� ����
    public float m_AttackSpeed;//�����Ǵ� ���ݼӵ�
    public float m_MovementSpeed;//�����Ǵ� �̵��ӵ�
    public Sprite m_Image;//������ �̹���
}
