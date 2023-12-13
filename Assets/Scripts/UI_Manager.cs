using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject m_statusUI;//캐릭터 스탯창 UI
    public GameObject m_inventoryUI;//인벤토리창 UI
    public GameObject m_healthBar;//체력바 UI
    public KeyCode m_openKey;//UI 온오프 키
    bool m_active;//UI 토글
    //private Camera m_camera; 경고 뜨는게 거슬려서 비활성화 시켰습니다.

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
            if (!m_active)//UI 활성화 또는 비활성화
            {
                m_statusUI.SetActive(true);
                m_inventoryUI.SetActive(true);
            }else
            {
                m_statusUI.SetActive(false);
                m_inventoryUI.SetActive(false);
            }

            m_active = !m_active;//토글
        }
        
        if (Input.GetMouseButtonDown(0))//클릭 이벤트 발생 시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//메인 카메라를 시작점으로 레이 생성
            RaycastHit hit;

            //Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 5f);//레이 테스트용

            if (Physics.Raycast(ray, out hit))//레이와 충돌한 오브젝트 접근
            {
                Debug.Log(hit.transform.name);//오브젝트의 이름 출력
            }
        }

    }
}
