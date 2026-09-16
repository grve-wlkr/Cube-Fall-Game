using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;

    private MeshRenderer mesh_Renderer;

    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        ResizeBackground();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += scroll_Speed * Time.deltaTime;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    private void ResizeBackground()
    {
        Camera mainCam = Camera.main;
        
        if (mainCam == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        // calculate exact world width and height of the camera view
        float worldHeight = mainCam.orthographicSize * 2f;
        float worldWidth = worldHeight * mainCam.aspect;

        // scale Quad (MeshRenderer) to cover the full screen
        if (mesh_Renderer != null)
        {
            transform.localScale = new Vector3(worldWidth, worldHeight, 1f);
        }

        // scale Sprite (SpriteRenderer) if used instead of a Quad
        else if(TryGetComponent<SpriteRenderer>(out SpriteRenderer sr) && sr.sprite != null)
        {
           Vector2 spriteSize = sr.sprite.bounds.size;
           transform.localScale = new Vector3(worldWidth / spriteSize.x, worldHeight / spriteSize.y, 1f); 
        } 
        
    }



} //class
