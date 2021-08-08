using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    #region Singlton:Profile
    public static Profile Instance;
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

    public class Avatar
    {
        public Sprite Image;
    }

    public List<Avatar> AvatarsList;

    [SerializeField] GameObject AvatarUITampelete;
    [SerializeField] Transform AvatarsScrollView;

    GameObject g;
    //int NewSelectedIndex, previousSelectedIndex;

    void start()
    {
        GetAvailableAvatars();
        //NewSelectedIndex = previousSelectedIndex = 0;
    }

    void GetAvailableAvatars()
    {
        for (int i = 0; i < shop.Instance.ShopItemList.Count; i++)
        {
            if (shop.Instance.ShopItemList[i].IsPurchased)
            {
                AddAvatar(shop.Instance.ShopItemList[i].Image);
            }
        }
    }

    public void AddAvatar(Sprite img)
    {
        if (AvatarsList == null)
            AvatarsList = new List<Avatar>();
        Avatar av = new Avatar() { Image = img };

        AvatarsList.Add(av);

        g = Instantiate(AvatarUITampelete, AvatarsScrollView);
        g.transform.GetChild(0).GetComponent<Image>().sprite = av.Image;

        //g.transform.GetComponent<Button>().AddEventListener(AvatarsList.Count - 1, OnAvatarClick);

    }

}

