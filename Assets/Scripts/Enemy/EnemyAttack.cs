using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public void Attack() {
        PlayerHealthController.instance.DealDamage();
    }
}
