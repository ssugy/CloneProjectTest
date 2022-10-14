using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ��� ����
/// </summary>
public class Std_ScrollViewShop : MonoBehaviour
{
    public GameObject itemSrc;  // ������ ���� �������ִ� ����
    public Transform itemParentTransform;

    private List<Std_item> itemList = new List<Std_item>();
    private Sprite[] itemSpriteList;
    void Start()
    {
        GameObject newItem = Instantiate<GameObject>(itemSrc);
        itemSpriteList = Resources.LoadAll<Sprite>("Icon/");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject newitem = Instantiate(itemSrc);
            newitem.transform.SetParent(itemParentTransform, false);
            newitem.SetActive(true);
            Std_item item = newitem.GetComponent<Std_item>();
            item.itemImg.sprite = itemSpriteList[Random.Range(0, itemSpriteList.Length)];
            itemList.Add(item);
        }
    }
}
