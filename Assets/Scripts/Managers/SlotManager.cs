using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public GameObject[] m_slots = new GameObject[12];//�κ��丮�� ����
    public GameObject[] m_equipSlots = new GameObject[4];//������ ��� ����
    public Sprite m_blankImage;//�׽�Ʈ�� ��ĭ �̹��� (�ϴ��� �����׸��)

    private InventoryManager m_playerInventory;
    private void Start()
    {
        m_playerInventory = GameManager.Instance.m_PlayerInventory;
        m_blankImage = Resources.Load<Sprite>("Blank");
        RefreshSlot();
    }

    public void RefreshSlot()//������ �ֽ�ȭ ��Ų��
    {
        foreach (var obj in m_slots)//�κ��丮 ���� �ʱ�ȭ
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = m_blankImage;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        foreach (var obj in m_equipSlots)//���� ��� ���� �ʱ�ȭ
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = m_blankImage;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        if (m_slots.Length >= m_playerInventory.m_Items.Count)//�κ��丮 ��� �����ͼ� �ֽ�ȭ
        {
            for (int x = 0; x < m_playerInventory.m_Items.Count; x++)
            {
                m_slots[x].transform.GetChild(0).GetComponent<Image>().sprite = m_playerInventory.m_Items[x].m_itemInfo.m_Image;
                m_slots[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = m_playerInventory.m_Items[x].m_itemStack.ToString();
            }
        }

        for (int x = 0; x < 4; x++)//��񽽷��� �ִ� 4������
        {
            if (m_playerInventory.m_EquipMents[x] != null)//������ ��� ���� ��쿡��
            {
                m_equipSlots[x].transform.GetChild(0).GetComponent<Image>().sprite = m_playerInventory.m_EquipMents[x].m_Image;
                m_equipSlots[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "E";
            }
        }
    }
}
