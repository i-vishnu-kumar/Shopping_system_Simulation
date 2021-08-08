using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    #region Singlton:shop
    public static shop Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [System.Serializable] public class ShopItems
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }

    public List<ShopItems> ShopItemList;
    GameObject g;
    [SerializeField] GameObject ItemTamplete;
    [SerializeField] Transform ShopScrollView;
    //[SerializeField] GameObject ShopPanel;

    Button buyBtn;

    // Start is called before the first frame update
    void Start()
    {
        int len = ShopItemList.Count;
        
        for (int i = 0; i<len; i++)
        {
            g = Instantiate(ItemTamplete, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();

            if (ShopItemList[i].IsPurchased == true)
            {
                DisableBuyButton();
            }

            buyBtn.AddEventListener(i, OnShopItemBtnCLicked);    //Change it to 'i' after removing the first indexed item which is not added automatically
        }
    }

    void OnShopItemBtnCLicked (int itemIndex)
    {
        if (Coins.Instance.HasEnoughCoins(ShopItemList[itemIndex].Price)) //removed -1
        {
            Coins.Instance.UseCoins(ShopItemList[itemIndex].Price);  //removed -1

            ShopItemList[itemIndex].IsPurchased = true;  //removed -1

            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();

            Coins.Instance.UpdateAllCoinsUIText();
            //Debug.Log(itemIndex);
            Profile.Instance.AddAvatar(ShopItemList[itemIndex].Image);
        }
        else
        {
            Debug.Log("YOU DON'T HAVE ENOUGH MONEY");
        }
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        //buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    
}
