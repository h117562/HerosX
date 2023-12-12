using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject m_statusUI;
    public GameObject m_inventoryUI;
    public GameObject m_healthBar;
    public KeyCode m_openKey;
    bool m_active;


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
            if (!m_active)
            {
                m_statusUI.SetActive(true);
                m_inventoryUI.SetActive(true);
            }else
            {
                m_statusUI.SetActive(false);
                m_inventoryUI.SetActive(false);
            }

            m_active = !m_active;
        }
    }
}
