using UnityEngine;

public class TopSpikesScaler : MonoBehaviour
{
    [Tooltip("Extra vertical offset to fine-tune placement relative to top of screen")]
    [SerializeField] private float yOffset = 0f;

    private void Start()
    {
        AlignToTop();
    }

    private void AlignToTop()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        // Direct math: Camera top Y = Camera Y position + orthographic size
        float topScreenY = cam.transform.position.y + cam.orthographicSize;

        // Calculate half height from collider if available
        float halfHeight = 0f;
        if (TryGetComponent(out BoxCollider2D col))
        {
            halfHeight = (col.size.y * 0.5f) - col.offset.y;
        }

        // Apply updated Y position
        Vector3 pos = transform.position;
        pos.y = topScreenY - halfHeight + yOffset;
        transform.position = pos;
    }



} // class