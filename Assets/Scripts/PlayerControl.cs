using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator m_animator;
    public Rigidbody2D m_rigidbody;
    public float m_speed;
    private Vector2 m_movement = Vector2.zero;
    private float m_delayToIdle = 0.0f;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;


    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator.SetBool("Grounded", true);//없으면 애니메이션 작동 안됨 (땅에 닿아 있을 때만 작동하게 해둬서)
    }
    
    // Update is called once per frame
    void Update()
    {
        m_movement = Vector2.zero;

        if (Input.GetKey(Up)) 
        {
            m_movement.y += m_speed; 
        }

        if (Input.GetKey(Down))
        {
            m_movement.y -= m_speed;
        }

        if (Input.GetKey(Left))
        {
            m_movement.x -= m_speed;
        }

        if (Input.GetKey(Right))
        {
            m_movement.x += m_speed;
        }

        m_rigidbody.velocity = m_movement;

      

        //이동 방향에 따라 바라보는 방향 전환
        if (m_movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (m_movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }


        //캐릭터 이동 애니메이션
        if (m_movement != Vector2.zero) 
        {
            m_delayToIdle = 0.05f;//가만히 있는 모션으로 전환 딜레이
            m_animator.SetInteger("AnimState", 1);
        }else
        {
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
        }
       
    }
}
