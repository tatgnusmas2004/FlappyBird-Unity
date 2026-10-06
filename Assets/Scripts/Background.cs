using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 2f; // Tốc độ background di chuyển
    public float width;


    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        // Mỗi frame, di chuyển Background sang bên trái.
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= -width * 2f) 
        {
            transform.position += Vector3.right * width * 6f;
        }
    }
}
