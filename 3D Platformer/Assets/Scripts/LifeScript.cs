using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeScript : MonoBehaviour
{
   
    public TextMeshProUGUI LifeText;
    private int CurrentLifes;
    private int LifeLeft;

   private void Start() {
       LifeText = GetComponent<TextMeshProUGUI>();
   }

   private void Update() {
      CurrentLifes = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getLifes();
      LifeLeft = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getLifes();
      LifeText.SetText("LIFES: " + CurrentLifes + "/" + LifeLeft);

   }
}
