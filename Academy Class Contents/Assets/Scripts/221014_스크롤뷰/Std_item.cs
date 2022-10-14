using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Std_item : MonoBehaviour
{
    public Image itemImg;
    public Text itemText;
    public Button itemBuyBtn;

    private void Awake()
    {
        itemImg = transform.GetChild(0).GetComponent<Image>();
        itemText = transform.GetChild(1).GetComponent<Text>();
        itemBuyBtn = transform.GetChild(2).GetComponent<Button>();
    }
}
