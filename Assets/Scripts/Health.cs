using UnityEngine;

///<summary>
/// Health component for a gameobject
///</summary>
public class Health : MonoBehaviour
{
    public int currentHealth;
    public int startingHealth;
    public int maxHealth;

    public int CurrentHealth
    {
        get{return currentHealth;}
    }

    private void Awake()
    {
        if(startingHealth > maxHealth)
        {
            startingHealth = maxHealth;
        }

        else if(startingHealth < 0)
        {
            startingHealth = 0;
        }

        currentHealth = startingHealth;
    }

    ///<summary>
    /// Add health to the gameobject. The health will never exceed the maxhealth, so any added health
    /// exceeding the max health is truncated.
    ///</summary>
    public void AddHealth(int addedHealth)
    {
        if(currentHealth + addedHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += addedHealth;
        }
    }

    ///<summary>
    /// Remove health from the gameobject. The health never goes below 0, so if the removed health
    /// makes the health go below 0 it is just set to 0.
    ///</summary>
    public void RemoveHealth(int removedHealth)
    {
        if(currentHealth - removedHealth < 0)
        {
            currentHealth = 0;
        }

        else
        {
            currentHealth -= removedHealth;
        }
    }

    ///<summary>
    /// Set the health to it's maximum value
    ///</summary>
    public void FillHealth()
    {
        currentHealth = maxHealth;
    }

    ///<summary>
    /// Sets the health to 0.
    ///</summary>
    public void EmptyHealth()
    {
        currentHealth = 0;
    }
    
}
