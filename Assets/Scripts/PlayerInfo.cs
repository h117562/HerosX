using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerInfo", menuName = "TopDownController/PlayerInfo/Default", order = 0)]
public class PlayerInfo : ScriptableObject
{
    [Header("Character Info")]
    public string m_playerName;
    public float m_playerSize;
    public float m_health;
    public float m_attack;
    public float m_attackSpeed;
    public float m_moveSpeed;
    public float m_defense;

    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
