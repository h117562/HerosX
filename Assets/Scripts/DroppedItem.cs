using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] public Item m_item;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_item.m_itemInfo.m_Image;//ItemInfo에 저장되있는 이미지로 변경
    }

    public void DestoryItem()//오브젝트 지연 삭제를 위한 함수
    {
        Destroy(gameObject);
    }
}
