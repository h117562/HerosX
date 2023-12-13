using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject m_statusUI;//ĳ���� ����â UI
    public GameObject m_inventoryUI;//�κ��丮â UI
    public GameObject m_healthBar;//ü�¹� UI
    public KeyCode m_openKey;//UI �¿��� Ű
    bool m_active;//UI ���
    //private Camera m_camera; ��� �ߴ°� �Ž����� ��Ȱ��ȭ ���׽��ϴ�.

    // Start is called before the first frame update
    void Start()
    {
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
            }else
            {
                m_statusUI.SetActive(false);
                m_inventoryUI.SetActive(false);
            }

            m_active = !m_active;//���
        }
        
        if (Input.GetMouseButtonDown(0))//Ŭ�� �̺�Ʈ �߻� ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//���� ī�޶� ���������� ���� ����
            RaycastHit hit;

            //Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 5f);//���� �׽�Ʈ��

            if (Physics.Raycast(ray, out hit))//���̿� �浹�� ������Ʈ ����
            {
                Debug.Log(hit.transform.name);//������Ʈ�� �̸� ���
            }
        }

    }
}
