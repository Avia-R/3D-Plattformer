using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameMaster instance;
    private int Coins;
    private int Lifes;
    private float Health;
    private int maxLifes;
    private float maxHealth;
    private int attackDamage;

    private float timer;
    private bool isUpdated;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        switch(sceneName)
        {
            case "Main Platform":
            if(!isUpdated)
            {
                GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>().setIsLevel(false);
                setTimer(500);
                setIsUpdated(true);
            }
                break;
            case "World 1 Level 1":
                GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>().setIsLevel(true);
                setIsUpdated(false);
                break;

            default:
            //do nothing
            break;
        }

        if(getLifes() <= 0)
        {
            SceneManager.LoadScene("Main Platform");
            setLifes(3);
            setHealth(50f);

        }
    }
    void Awake()
    {
       MakeSingleton();
       setCoins(0);
       setHealth(50f);
       setLifes(3);
       setMaxHealth(50f);
       setMaxLifes(3);
       setAttackDamage(10);
       setIsUpdated(false);
    }

    public void setIsUpdated(bool newBool)
    {
        isUpdated = newBool;
    }

    public float getTime()
    {
        return timer;
    }
    public void setTimer(float newTimer)
    {
        timer = newTimer;
    }

    public void increaseTimer(float newTime) 
        {
            timer += newTime;
        }

    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getCoins()
    {
        return Coins;
    }

    public void setCoins(int coins) 
    {   
    Coins = Coins + coins;   
    }

    public int getLifes()
    {
        return Lifes;
    }

    public void setLifes(int lifes)
    {
        Lifes = Lifes + lifes;
    }

    public float getHealth()
    {
        return Health;
    }

    public void setHealth(float health)
    {
        Health = Health + health;
        if(Health > maxHealth)
        {
            Health = maxHealth;
        }
    }
    public int getMaxLifes()
    {
        return maxLifes;
    }

    public void setMaxLifes(int lifes)
    {
        maxLifes = maxLifes + lifes;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void setMaxHealth(float health)
    {
        maxHealth = maxHealth + health;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    public void setAttackDamage(int damage)
    {
        attackDamage = attackDamage + damage;
    }
}
