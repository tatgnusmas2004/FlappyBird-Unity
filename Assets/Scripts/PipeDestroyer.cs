using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    public float destroyX = -15f;

    void Update()
    {
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
