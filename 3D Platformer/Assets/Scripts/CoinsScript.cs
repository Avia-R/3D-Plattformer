using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;
    private float CurrentCoins;

   private void Start() {
       CoinsText = GetComponent<TextMeshProUGUI>();
   }

   private void Update() {
      CurrentCoins = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getCoins();
      CoinsText.SetText("COINS: " + CurrentCoins);

   }
}
