using UnityEngine;

public class PhoneScreenScaler : MonoBehaviour
{
    public Camera cam;
    public Vector2 initScale;
    private Vector2 topRight;
    public Transform screen;
    void Start()
    {
        topRight = cam.ViewportToWorldPoint(initScale);
        screen.localScale = topRight;
    }
    void Update()
    {
        Start();
    }
    public Vector2 getTopRight()
    {
        return cam.ViewportToWorldPoint(initScale);
    }
}
