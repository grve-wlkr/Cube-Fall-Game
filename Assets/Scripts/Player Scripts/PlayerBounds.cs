using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [Header("Bounds Settings")]
    [SerializeField] private bool useDynamicBounds = true;
    [SerializeField] private float min_X = -1.6f, max_X = 1.6f, min_Y = -5.6f;

    [Header("Dynamic Padding")]
    [SerializeField] private float xPadding = 0.3f;
    [SerializeField] private float bottomOffset = 0.5f;

    private bool isDead;

    private void Start()
    {
        if (!useDynamicBounds || Camera.main == null) return;

        Camera cam = Camera.main;
        float halfWidth = cam.orthographicSize * cam.aspect;

        min_X = -halfWidth + xPadding;
        max_X = halfWidth - xPadding;
        min_Y = cam.transform.position.y - cam.orthographicSize - bottomOffset;
    }

    private void Update() => CheckBounds();

    private void CheckBounds()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min_X, max_X);
        transform.position = pos;

        if (pos.y <= min_Y) TriggerDeath();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("TopSpike")) TriggerDeath();
    }

    private void TriggerDeath()
    {
        if (isDead) return;
        isDead = true;

        SoundManager.instance.DeathSound();
        GameManager.instance.GameOver();
    }
}