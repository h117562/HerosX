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
    public ItemType m_Type;//아이템 종류
    public int m_ItemId;//아이템 코드
    public string m_ItemName;//이름
    public string m_Description;//설명
    public int m_Damage;//증가되는 공격력
    public int m_Defense;//증가되는 방어력
    public float m_AttackSpeed;//증가되는 공격속도
    public float m_MovementSpeed;//증가되는 이동속도
    public Sprite m_Image;//아이템 이미지
}
