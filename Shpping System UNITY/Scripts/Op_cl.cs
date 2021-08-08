using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Op_cl : MonoBehaviour
{
    public void openShop()
    {
        gameObject.SetActive(true);
    }
    public void closeShop()
    {
        gameObject.SetActive(false);
    }
}
