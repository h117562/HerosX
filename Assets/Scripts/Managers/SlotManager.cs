using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public GameObject[] m_slots = new GameObject[12];//인벤토리의 슬롯
    public GameObject[] m_equipSlots = new GameObject[4];//장착한 장비 슬롯
    public Sprite m_blankImage;//테스트용 빈칸 이미지 (일단은 검은네모로)

    private InventoryManager m_playerInventory;
    private void Start()
    {
        m_playerInventory = GameManager.Instance.m_PlayerInventory;
        m_blankImage = Resources.Load<Sprite>("Blank");
        RefreshSlot();
    }

    public void RefreshSlot()//슬롯을 최신화 시킨다
    {
        foreach (var obj in m_slots)//인벤토리 슬롯 초기화
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = m_blankImage;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        foreach (var obj in m_equipSlots)//착용 장비 슬롯 초기화
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = m_blankImage;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        if (m_slots.Length >= m_playerInventory.m_Items.Count)//인벤토리 요소 가져와서 최신화
        {
            for (int x = 0; x < m_playerInventory.m_Items.Count; x++)
            {
                m_slots[x].transform.GetChild(0).GetComponent<Image>().sprite = m_playerInventory.m_Items[x].m_itemInfo.m_Image;
                m_slots[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = m_playerInventory.m_Items[x].m_itemStack.ToString();
            }
        }

        for (int x = 0; x < 4; x++)//장비슬롯은 최대 4개뿐임
        {
            if (m_playerInventory.m_EquipMents[x] != null)//착용한 장비가 있을 경우에만
            {
                m_equipSlots[x].transform.GetChild(0).GetComponent<Image>().sprite = m_playerInventory.m_EquipMents[x].m_Image;
                m_equipSlots[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "E";
            }
        }
    }
}
