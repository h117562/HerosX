using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStatusInfo", menuName = "TopDownController/StatusInfo/Default", order = 0)]
public class StatusInfo : ScriptableObject
{
    [Header("Character Info")]
    public string m_PlayerName;
    public float m_PlayerSize;
    public float m_Health;
    public float m_AttackDamage;
    public float m_AttackSpeed;
    public float m_MoveSpeed;
    public float m_Defense;
}
