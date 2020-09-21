using UnityEngine;

public class PhoneScreenScaler : MonoBehaviour
{
    public Camera cam;
    public bool update;
    public Vector2 initScale;
    private Vector2 cam2screen;
    void Start()
    {
        cam2screen = cam.ViewportToWorldPoint(initScale);
    }
    void Update()
    {
        Start();
    }
}
