using UnityEngine;

public class GroundScrolling : MonoBehaviour
{
    public float speed = 2f;

    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width * 2f)
        {
            transform.position += Vector3.right * width * 6f;
        }
    }
}
