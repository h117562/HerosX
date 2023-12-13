using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InventoryManager m_PlayerInventory;
    public InterfaceManager m_InterfaceManager;
    public StatManager m_PlayerStats;

    public GameObject item1;//테스트용 변수
    public GameObject item2;

    public ItemInfo test_itemInfo;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        temp = Instantiate(item1);//테스트용 변수
        temp.transform.position = new Vector3(5, 0, 1);
        temp = Instantiate(item2);
        temp.transform.position = new Vector3(5, 1, 1);

        temp = Instantiate(item1);//테스트용 변수
        temp.transform.position = new Vector3(15, 0, 1);
        temp = Instantiate(item2);
        temp.transform.position = new Vector3(15, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
