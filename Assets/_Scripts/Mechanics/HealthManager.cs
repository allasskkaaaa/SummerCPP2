using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    public int health = 100;
    public int maxHealth = 100;
    public int lives = 1;

    [SerializeField] private TMP_Text healthText;
    
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();

        if (gameObject.CompareTag("Player"))
        {
            healthText = GameObject.FindWithTag("PlayerHealthText").GetComponent<TMP_Text>();
            healthBar = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + "has been taken.");
        float healthPercentage = Mathf.Clamp01((float)health / maxHealth); 
        healthBar.fillAmount = healthPercentage;
        if (gameObject.CompareTag("Player"))
        {
            healthText.text = "Health: " + health;
        }
        if (health <= 0)
        {
            lives--;
            if (lives <= 0)
            {
                DeathAnimation();
                
            } else
            {
                respawn();
            }
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
        if (gameObject.CompareTag("Player"))
        {
            healthText.text = "Health" + health;
        }
    }

    public void DeathAnimation()
    {
        anim.SetTrigger("death");
    }

    public void deleteObject()
    {
        Destroy(gameObject);
    }

   public void respawn()
    {
        GameManager.Instance.Respawn();
    }
}