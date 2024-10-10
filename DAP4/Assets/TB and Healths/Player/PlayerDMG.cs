using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMG : MonoBehaviour
{
    
    [Header("Player Health Var")]
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthBar playerHealthScript;

    [Header("Player TB Var")]
    public int maxTB = 100;
    public int currentTBAmount;
    public TB_Bar TBScript;
    float delayEffect = 1.0f;

    //[Header("For Attacking")] //attacking may just be handled in its own seperate script

    //[Tooltip("This one is temporary")] public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth= maxHealth;
        playerHealthScript.SetMaxHealth(maxHealth);

        
    }
    private void Awake()
    {
        currentTBAmount= 0; //When game starts for the first time, player should not have TB at all
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = (int)Mathf.Clamp(currentHealth, 0f, maxHealth);  // Clamp current health so it stays between 0 and maxHealth
        currentTBAmount = (int)Mathf.Clamp(currentTBAmount, 0f, maxTB);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            
        }
        //Test for attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            //weapon.SetActive(true);
            IncrementTB(30);
            Debug.Log("Incrementing TB");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            //weapon.SetActive(false);
            
        }
        //End test
        if (currentTBAmount >= maxTB)
        {

            TakeTB_Damage();
            
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth-= damage;
        playerHealthScript.SetHealth(currentHealth);  //Take damage() updates player health bar
    }
    public void IncrementTB(int tbAmount)
    {
        currentTBAmount += tbAmount;
        TBScript.SetTBAmount(currentTBAmount);   
        
    }
    public void HealDamage(int healAmount, Collision collisionObj)
    {
        
        if (collisionObj.gameObject.name == "HealHealth")
        {
            currentHealth += healAmount;
            playerHealthScript.SetHealth(currentHealth);
            Debug.Log("Health Called");
            Destroy(collisionObj.gameObject);
        }
        if(collisionObj.gameObject.name == "HealTB")
        {
            currentTBAmount -= healAmount;
            TBScript.SetTBAmount(currentTBAmount);
            Debug.Log("Heal TB Called");
            Destroy(collisionObj.gameObject);
        }
        
          
    }
    private void TakeTB_Damage()
    {
        
        float timePassed = 0.0f;
        
        
        timePassed += Time.time;
        Debug.Log("timePassed: " + timePassed);
        

        if (timePassed >= delayEffect)
        {
            delayEffect+=10.0f;  //adding 1 to delay effect so that the TB affects the player within longer intervals each time.
            Debug.Log("delayEffect: "+ delayEffect);
            
            timePassed = 0f; // Reset timer if needed for repeat
            
            TakeDamage(5);
        }


    }
}
