using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cam;
    public Transform[] backgrounds;
    public float parallaxDelta;

    private float _lastCamXPos;
    private float _lastCamYPos;
    private void Start() {
        _lastCamXPos = cam.position.x;
        _lastCamYPos = cam.position.y;
    }

    private void LateUpdate() {
        float amountToMoveX = cam.position.x - _lastCamXPos;
        float amountToMoveY = cam.position.y - _lastCamYPos;
        float parallaxValueX = 1;
        float parallaxValueY = 1;
        _lastCamXPos = cam.position.x;
        _lastCamYPos = cam.position.y;
        for (int i = 0; i < backgrounds.Length; i++) {
            backgrounds[i].position = backgrounds[i].position + new Vector3(amountToMoveX * parallaxValueX, amountToMoveY * parallaxValueY, 0);
            parallaxValueX -= parallaxDelta;
            parallaxValueY -= parallaxDelta;
        }
    }
}
