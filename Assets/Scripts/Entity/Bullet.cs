using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform obj;
    public float speed;
    private Vector3 direction;
    public ParticleSystem particle;
    public Transform particleTransform;
    void Start()
    {
        float radAng = obj.eulerAngles.z * Mathf.PI / 180;
        direction = new Vector3(Mathf.Cos(radAng), Mathf.Sin(radAng));
    }
    void Update()
    {
        obj.position += direction * speed * Time.deltaTime;
        particleTransform.position = obj.position;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        string tag = collider.gameObject.tag;
        if (tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().Kill();
            var main = particle.main;
            main.loop = false;
            Destroy(gameObject);
        }
        if (tag == "Wall0" | tag == "Wall1" | tag == "Wall2" | tag == "Wall3")
        {
            var main = particle.main;
            main.loop = false;
            Destroy(gameObject);
        }
    }
    public void SetParticle(GameObject part)
    {
        particle = part.GetComponent<ParticleSystem>();
        particleTransform = part.transform;
}
}
