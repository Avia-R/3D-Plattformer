using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackDamage : MonoBehaviour
{
    // Start is called before the first frame update
   private TextMeshProUGUI AttackText;
    private float CurrentDamage; 

   private void Start() {
       AttackText = GetComponent<TextMeshProUGUI>();
   }

   private void Update() {
      CurrentDamage = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getAttackDamage();
      AttackText.SetText("ATTACK DAMAGE: " + CurrentDamage);

   }
}
