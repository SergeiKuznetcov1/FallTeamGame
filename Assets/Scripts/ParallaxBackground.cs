using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cam;
    public Transform[] backgrounds;
    public float parallaxMultiplier;
    private float _lastXPos;
    private float _lastYPos;
    private void Start() {
        _lastXPos = cam.position.x;
        _lastYPos = cam.position.y;
    }

    private void LateUpdate() {
        float amountToMoveX = cam.position.x - _lastXPos;
        float amountToMoveY = cam.position.y - _lastYPos;
        float parallaxValue = 1;
        _lastXPos = cam.position.x;
        _lastYPos = cam.position.y;
        for (int i = 0; i < backgrounds.Length; i++) {
            backgrounds[i].position = backgrounds[i].position + new Vector3(amountToMoveX * parallaxValue, amountToMoveY * parallaxValue, 0);
            parallaxValue *= parallaxMultiplier;
        }

    }
}
