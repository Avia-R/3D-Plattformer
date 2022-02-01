using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    private float CurrentTime;
    private bool isLevel;

    private float elapsed;

   private void Start() {
       TimeText = GetComponent<TextMeshProUGUI>();
       isLevel = false;
   }

   private void Update() {
       if(isLevel)
       {
         elapsed += Time.deltaTime;
         if(elapsed >= 1f)
         {
             elapsed = 0f;
             DoFlash();
         }
       }
       else
       {
           TimeText.SetText("TIME: ---" );
       }
      

   }
    public void DoFlash()
       {
           Debug.Log("Wait!");
           GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().increaseTimer(-1);
           CurrentTime = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getTime();
           TimeText.SetText("TIME: " + CurrentTime);
           if(CurrentTime <=0)
           {
               GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().OnDeath();
               GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setTimer(300);
           }
       }

   public void setIsLevel(bool setting)
   {
       isLevel = setting;
   }
}
