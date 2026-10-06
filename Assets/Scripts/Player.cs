using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [Header("Bird Animation")]
    public Sprite[] sprites;
    private int spriteIndex;

    [Header("Bird Physics")]
    public float strength = 5f;

    [Header("Bird Rotation")]
    public float flapRotation = 25f;
    public float fallRotation = -90f;
    public float rotationSpeed = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
            return;

        if (gameManager.gameOver)
            return;

        // Nhấn Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // Click chuột
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }

        // Touch mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Flap();
            }
        }

        UpdateRotation();
    }

    private void Flap()
    {
        // Cho chim bay lên
        rb.linearVelocity = new Vector2(0f, strength);

        // Ngóc đầu lên ngay khi flap
        transform.rotation = Quaternion.Euler(0f, 0f, flapRotation);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayFlap();
        }
    }

    private void UpdateRotation()
    {
        float targetRotation;

        // Đang bay lên
        if (rb.linearVelocity.y > 0)
        {
            targetRotation = flapRotation;
        }
        // Đang rơi
        else
        {
            targetRotation = fallRotation;
        }

        // Xoay mượt
        Quaternion targetQuaternion =
            Quaternion.Euler(0f, 0f, targetRotation);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetQuaternion,
            rotationSpeed * Time.deltaTime
        );
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
