using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] m_slots = new GameObject[12];
    public Sprite m_blankImage;
    
    private void Start()
    { 
        m_blankImage = Resources.Load<Sprite>("Blank");
        RefreshSlot();
    }
    
    public void RefreshSlot()
    {
        foreach (var obj in m_slots)
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = m_blankImage;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        if (m_slots.Length >= Player.I.m_items.Count)
        {
            for (int x = 0; x < Player.I.m_items.Count; x++)
            {
                m_slots[x].transform.GetChild(0).GetComponent<Image>().sprite = Player.I.m_items[x].m_itemInfo.m_Image;
                m_slots[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Player.I.m_items[x].m_itemStack.ToString();
            }
        }
    }
}
