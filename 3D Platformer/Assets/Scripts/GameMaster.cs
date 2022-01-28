using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
       MakeSingleton();
       setCoins(0);
       setHealth(50f);
       setLifes(2);
       setMaxHealth(50f);
       setMaxLifes(3);
       setAttackDamage(10);
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
