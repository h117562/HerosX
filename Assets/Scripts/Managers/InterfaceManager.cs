using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class InterfaceManager : MonoBehaviour
{
    public GameObject m_statusUI;//캐릭터 스탯창 UI
    public GameObject m_inventoryUI;//인벤토리창 UI
    public GameObject m_healthBar;//체력바 UI
    public SlotManager m_slotManager;

    [Header("Status Text")]
    public GameObject m_playerNameText;
    public GameObject m_ADtext;//Attack Damage
    public GameObject m_DFtext;//Defense
    public GameObject m_MStext;//Movement Speed

    [Header("Inventory Text")]
    public GameObject m_itemNameText;//아이템 이름 텍스트
    public GameObject m_itemDescText;//아이템 설명 텍스트

    [Header("UI Open Key")]
    public KeyCode m_openKey;//UI 온오프 키

    //private Camera m_camera; 경고 뜨는게 거슬려서 비활성화 시켰습니다.
    private bool m_active;//UI 토글
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
            if (!m_active)//UI 활성화 또는 비활성화
            {
                m_statusUI.SetActive(true);
                m_inventoryUI.SetActive(true);
            }
            else
            {
                m_statusUI.SetActive(false);
                m_inventoryUI.SetActive(false);
            }

            m_active = !m_active;//토글
        }

        if (Input.GetMouseButtonDown(0))//좌클릭 이벤트 발생 시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//메인 카메라를 시작점으로 레이 생성
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))//레이와 충돌한 오브젝트 접근
            {
                if (hit.transform.parent.parent.name == "Inventory")//인벤토리안에 슬롯을 클릭했을 경우
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
                else//특정 슬롯 말고 아무 공간을 클릭했을 때 이름과 설명 지우기
                {
                    m_itemNameText.GetComponent<TextMeshProUGUI>().text = "";
                    m_itemDescText.GetComponent<TextMeshProUGUI>().text = "";
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))//우클릭 이벤트 발생 시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//메인 카메라를 시작점으로 레이 생성
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))//레이와 충돌한 오브젝트 접근
            {
                if (hit.transform.parent.parent.name == "Inventory")//인벤토리안에 슬롯을 클릭했을 경우
                {
                    m_Player1Inventory.SwapEquip(int.Parse(hit.transform.name));

                }

                if (hit.transform.parent.name == "Equipments")//상태창안에 슬롯을 클릭했을 경우
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
