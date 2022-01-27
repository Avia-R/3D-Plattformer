using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthScript : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private float CurrentHealth;
   private float MaxHealth;

   private void Start() {
       healthText = GetComponent<TextMeshProUGUI>();
   }

   private void Update() {
      CurrentHealth = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getHealth();
      MaxHealth = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getMaxHealth();
      healthText.SetText("HEALTH: " + CurrentHealth + "/" + MaxHealth);

   }
}
