using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
	#region SIngleton:Coins

	public static Coins Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	#endregion

	[SerializeField] Text[] allCoinsUIText;

	public int Coinsnum;

	void Start()
	{
		UpdateAllCoinsUIText();
	}

	public void UseCoins(int amount)
	{
		Coinsnum -= amount;
	}

	public bool HasEnoughCoins(int amount)
	{
		return (Coinsnum >= amount);
	}

	public void UpdateAllCoinsUIText()
	{
		for (int i = 0; i < allCoinsUIText.Length; i++)
		{
			allCoinsUIText[i].text = Coinsnum.ToString();
		}
	}

}

