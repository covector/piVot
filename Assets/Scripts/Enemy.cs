using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public Transform obj;
    public float discount;
    public float speed;
    public void face()
    {
        Vector2 vec = target.position - obj.position;
        float targetAngle = Mathf.Atan2(vec.y, vec.x) * 180 / Mathf.PI;
        targetAngle = (targetAngle + 360) % 360;
        float viewAngle = obj.eulerAngles.z;
        int quad1t = targetAngle < 90f ? 1 : 0;
        int quad1v = viewAngle < 90f ? 1 : 0;
        float threshold = targetAngle * quad1t + viewAngle * quad1v + 180f;
        int quad4 = (targetAngle > threshold | viewAngle > threshold) ? 1 : 0;
        targetAngle -= quad1v * quad4 * 360f;
        viewAngle -= quad1t * quad4 * 360f;
        float delta = targetAngle - viewAngle;
        viewAngle += delta * discount; //Exponential / Frame Dependent

        //float deltaScaled = Mathf.Sign(delta) * discount * Time.deltaTime;
        //viewAngle += Mathf.Min(delta, deltaScaled); //Linear / Frame Independent
        obj.eulerAngles =  new Vector3(0f, 0f, viewAngle);
    }
    public static float screenScale;
    public void walk()
    {
        float radAng = obj.eulerAngles.z * Mathf.PI / 180;
        obj.position += screenScale * speed * Time.deltaTime * new Vector3(Mathf.Cos(radAng), Mathf.Sin(radAng), 0);
    }
    public void Kill()
    {
        StartCoroutine(FindObjectOfType<SpawnManager>().Respawn());
        Destroy(gameObject);
    }
    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }
    void Update()
    {
        face();
        walk();
    }
}
