using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cam;
    public Transform[] backgrounds;
    public float parallaxDelta;

    private float _lastXPos;
    private float _lastYPos;
    private void Start() {
        _lastXPos = cam.position.x;
        _lastYPos = cam.position.y;
    }

    private void LateUpdate() {
        float amountToMoveX = cam.position.x - _lastXPos;
        float amountToMoveY = cam.position.y - _lastYPos;
        float parallaxValueX = 1;
        float parallaxValueY = 1;
        _lastXPos = cam.position.x;
        _lastYPos = cam.position.y;
        for (int i = 0; i < backgrounds.Length; i++) {
            backgrounds[i].position = backgrounds[i].position + new Vector3(amountToMoveX * parallaxValueX, amountToMoveY * parallaxValueY, 0);
            parallaxValueX += parallaxDelta;
            parallaxValueY -= parallaxDelta;
        }

    }
}
