using System;
using UnityEngine;


public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}


[Serializable]
public class PlayerInfo
{
    public StatsChangeType m_statsChangeType;

    [Range(0, 100)] public int m_maxHealth;
    [Range(0, 100)] public int m_maxStamina;
    [Range(0.0f, 10.0f)] public int m_speed;

    public AttackSO m_attackSO;
}
