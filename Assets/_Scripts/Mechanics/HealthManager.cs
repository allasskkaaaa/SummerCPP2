using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private ParticleSystem bloodParticles;
    [SerializeField] public int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxLives;
    [SerializeField] public int lives = 1;
    public AudioClip DamageSFX;

    [SerializeField] private TMP_Text healthText;
    
    
    SoundManager soundManager;
    Animator anim;
    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        anim = GetComponent<Animator>();
        //bloodParticles.Stop();

        if (gameObject.CompareTag("Player"))
        {
            if (healthText == null)
                healthText = GameObject.FindWithTag("PlayerHealthText").GetComponent<TMP_Text>();

            if (healthBar == null)
                healthBar = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
        }
    }


    private void Update()
    {
        if (healthText == null)
        {
            healthText = GameObject.FindWithTag("PlayerHealthText").GetComponent<TMP_Text>();
        }

        if (healthBar == null)
        {
            healthBar = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
        }

        updateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " damage has been taken.");
        updateHealthBar();
        soundManager.playSFX(DamageSFX);
        if (bloodParticles)
        {
            bloodParticles.Play();
        }
        
        if (gameObject.CompareTag("Player"))
        {
            healthText.text = "Health: " + health;
        }
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                lives--;
                if (lives <= 0)
                {
                    DeathAnimation();                 

                }
                else
                {
                    respawn();
                }
            } 
            
        }


    }

    public void AddHealth(int hp)
    {
        health += hp;
        Debug.Log(hp + " health has been added.");
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        updateHealthBar();
        if (gameObject.CompareTag("Player"))
        {
            healthText.text = "Health: " + health;
        }
    }

    public void DeathAnimation()
    {
        anim.SetTrigger("death");
    }

    public void GameOver()
    {
        GameManager.Instance.LoadScene(3);
    }

   public void respawn()
    {
        resetHealth();
        GameManager.Instance.Respawn();
    }

    public void resetHealth()
    {
        Debug.Log("Health has been reset");
        health = maxHealth;
    }

    public void resetLives()
    {
        lives = maxLives;
    }

    public void updateHealthBar()
    {
        float healthPercentage = Mathf.Clamp01((float)health / maxHealth);  // Cast to float
        healthBar.fillAmount = healthPercentage;
    }
}