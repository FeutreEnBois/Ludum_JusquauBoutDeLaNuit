using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool isInvincible;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        CheckLife(currentHealth);
    }

    public void ToggleInvincibilities()
    {
        isInvincible = !isInvincible;
    }
    private void CheckLife(float currentHealth)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("player is dead");
        }
    }
}
