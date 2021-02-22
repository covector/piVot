using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    public Constants constants;
    Camera cam;
    float scaleTo;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        scaleTo = constants.areaRadius;
    }

    void Update()
    {
        UpdateScreenScale();
    }

    public void UpdateScreenScale()
    {
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1f, 1f));
        float minSide = Mathf.Min(topRight.x, topRight.y);
        float scale = scaleTo / minSide;
        cam.orthographicSize *= scale;
    }
}