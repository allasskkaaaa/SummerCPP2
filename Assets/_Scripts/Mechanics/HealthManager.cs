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
        float healthPercentage = Mathf.Clamp01(health / maxHealth);
        healthBar.fillAmount = healthPercentage;
        if (health <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}