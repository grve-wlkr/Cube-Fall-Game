using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;

    private MeshRenderer mesh_Renderer;

    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
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



} //class
