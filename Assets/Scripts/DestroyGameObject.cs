using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
	[SerializeField] float lifeDuration;

    private void Start() {
        Destroy(gameObject, lifeDuration);
    }
}
