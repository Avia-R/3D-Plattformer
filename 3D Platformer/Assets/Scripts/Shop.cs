using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject ShopUI;
    public GameObject PlayerStats;
    public TextMeshProUGUI Textfield;


    private float coins;

    public GameObject Camera;
    public void buyHealth()
    {
        coins = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getCoins();
        if(coins - 20 >= 0)
        {
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setMaxHealth(10);
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setCoins(-20);
            setText("Successfully purchased!");
        }
        else
        {
            setText("You don't have enough Coins!");
        }
    }

    public void buyLifes()
    {
        coins = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getCoins();
        if(coins - 20 >=0)
        {
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setMaxLifes(1);
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setCoins(-20);
            
           setText("Successfully purchased!");
        }
        else
        {
            setText("You don't have enough Coins!");
        }
         
    }

    public void buyAttack()
    {
        coins = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().getCoins();
        if(coins - 20 >=0)
        {
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setAttackDamage(10);
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameMaster>().setCoins(-20);
            setText("Successfully purchased!");
        }
        else
        {
            setText("You don't have enough Coins!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.GetComponent<PlayerMovement>().setmouseEnable(false);
            setText("Please Purchase!");
            Camera.SetActive(false);
            PlayerStats.SetActive(false);
            ShopUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.GetComponent<PlayerMovement>().setmouseEnable(true);
            Camera.SetActive(true);
            PlayerStats.SetActive(true);
            ShopUI.SetActive(false);
        } 
    }

    private void setText(string newText)
    {
        Textfield = GetComponent<TextMeshProUGUI>();
        Textfield.SetText(newText);
    }
}
