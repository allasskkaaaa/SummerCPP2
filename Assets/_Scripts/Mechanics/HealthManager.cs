using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    public int health = 100;
    public int maxHealth = 100;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public bool IsDead()
    {
        return health <= 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + "has been taken.");
        float healthPercentage = Mathf.Clamp01((float)health / maxHealth); 
        healthBar.fillAmount = healthPercentage;
        if (health <= 0)
        {
            DeathAnimation();
        }
    }

    public void AddHealth(int hp)
    {
        health += hp;
        Debug.Log(hp + "has been added.");
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        float healthPercentage = Mathf.Clamp01((float)health / maxHealth);  // Cast to float
        healthBar.fillAmount = healthPercentage;
    }

    public void DeathAnimation()
    {
        anim.SetTrigger("death");
    }

    public void deleteObject()
    {
        Destroy(gameObject);
    }
}