using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
	public int currentHealth;
	public int maxHealth;
    [SerializeField] private float _invincibleLength;
	[SerializeField] private float _invincibleCounter;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update() {
        if (_invincibleCounter > 0) {
            _invincibleCounter -= Time.deltaTime;
        }
    }

    public void DealDamage() {
        if (_invincibleCounter <= 0) {
            currentHealth--;

            if (currentHealth <= 0) {
                currentHealth = 0;
                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            } else {
                _invincibleCounter = _invincibleLength;
                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }
}
