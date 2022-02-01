using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
   private Image HealthBar;
   private float CurrentHealth;
   private float MaxHealth;

   private void Start() {
       HealthBar = GetComponent<Image>();
   }

   private void Update() {
      CurrentHealth = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getHealth();
      MaxHealth = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getMaxHealth();
      HealthBar.fillAmount = CurrentHealth / MaxHealth;

   }
}
