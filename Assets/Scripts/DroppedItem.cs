using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] public Item m_item;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_item.m_itemInfo.m_Image;//ItemInfo�� ������ִ� �̹����� ����
    }

    public void DestoryItem()//������Ʈ ���� ������ ���� �Լ�
    {
        Destroy(gameObject);
    }
}
