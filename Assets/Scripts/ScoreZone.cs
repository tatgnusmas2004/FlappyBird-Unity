using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scored)
            return;

        if (collision.CompareTag("Player"))
        {
            scored = true;
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore();
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.PlayScore();
                }
            }
        }
    }
}
