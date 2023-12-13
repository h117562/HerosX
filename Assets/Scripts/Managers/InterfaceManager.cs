using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class InterfaceManager : MonoBehaviour
{
    public GameObject m_statusUI;//ĳ���� ����â UI
    public GameObject m_inventoryUI;//�κ��丮â UI
    public GameObject m_healthBar;//ü�¹� UI
    public SlotManager m_slotManager;

    [Header("Status Text")]
    public GameObject m_playerNameText;
    public GameObject m_ADtext;//Attack Damage
    public GameObject m_DFtext;//Defense
    public GameObject m_MStext;//Movement Speed

    [Header("Inventory Text")]
    public GameObject m_itemNameText;//������ �̸� �ؽ�Ʈ
    public GameObject m_itemDescText;//������ ���� �ؽ�Ʈ

    [Header("UI Open Key")]
    public KeyCode m_openKey;//UI �¿��� Ű

    //private Camera m_camera; ��� �ߴ°� �Ž����� ��Ȱ��ȭ ���׽��ϴ�.
    private bool m_active;//UI ���
    private InventoryManager m_Player1Inventory;
    private StatManager m_Player1Stats;

    // Start is called before the first frame update
    void Start()
    {
        m_Player1Stats = GameManager.Instance.m_PlayerStats;
        m_Player1Inventory = GameManager.Instance.m_PlayerInventory;
        m_active = false;
        m_statusUI.SetActive(false);
        m_inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(m_openKey))
        {
            if (!m_active)//UI Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
            {
                m_statusUI.SetActive(true);
                m_inventoryUI.SetActive(true);
            }
            else
            {
                m_statusUI.SetActive(false);
                m_inventoryUI.SetActive(false);
            }

            m_active = !m_active;//���
        }

        if (Input.GetMouseButtonDown(0))//��Ŭ�� �̺�Ʈ �߻� ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���� ī�޶� ���������� ���� ����
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))//���̿� �浹�� ������Ʈ ����
            {
                if (hit.transform.parent.parent.name == "Inventory")//�κ��丮�ȿ� ������ Ŭ������ ���
                {
                    int index = (int.Parse(hit.transform.name));
                    Item item = m_Player1Inventory.m_Items[index];
                    string name = m_Player1Inventory.GetItem(index).m_itemInfo.m_ItemName;

                    if (item != null)
                    {
                        m_itemNameText.GetComponent<TextMeshProUGUI>().text = item.m_itemInfo.m_ItemName;
                        m_itemDescText.GetComponent<TextMeshProUGUI>().text = item.m_itemInfo.m_Description;
                    }
                }
                else//Ư�� ���� ���� �ƹ� ������ Ŭ������ �� �̸��� ���� �����
                {
                    m_itemNameText.GetComponent<TextMeshProUGUI>().text = "";
                    m_itemDescText.GetComponent<TextMeshProUGUI>().text = "";
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))//��Ŭ�� �̺�Ʈ �߻� ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���� ī�޶� ���������� ���� ����
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))//���̿� �浹�� ������Ʈ ����
            {
                if (hit.transform.parent.parent.name == "Inventory")//�κ��丮�ȿ� ������ Ŭ������ ���
                {
                    m_Player1Inventory.SwapEquip(int.Parse(hit.transform.name));

                }

                if (hit.transform.parent.name == "Equipments")//����â�ȿ� ������ Ŭ������ ���
                {
                    m_Player1Inventory.Unequip(int.Parse(hit.transform.name));

                }
            }
        }

        if(Input.anyKeyDown)
        {
           m_slotManager.RefreshSlot();
           RefreshStatus();
        }
     
    }

    private void RefreshStatus()
    {
        float damage, defense, speed;

        damage = m_Player1Stats.m_StatusInfo.m_AttackDamage + m_Player1Inventory.GetDamage();
        defense = m_Player1Stats.m_StatusInfo.m_Defense + m_Player1Inventory.GetDefense();
        speed = m_Player1Stats.m_StatusInfo.m_MoveSpeed;

        m_playerNameText.GetComponent<TextMeshProUGUI>().text = m_Player1Stats.m_StatusInfo.m_PlayerName;
        m_ADtext.GetComponent<TextMeshProUGUI>().text = damage.ToString();
        m_DFtext.GetComponent<TextMeshProUGUI>().text = defense.ToString();
        m_MStext.GetComponent<TextMeshProUGUI>().text = speed.ToString();
    }
}
