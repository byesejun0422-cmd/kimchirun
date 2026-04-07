using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Material material;
    private Vector2 offset;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            material = meshRenderer.material;
        }
    }

    void Update()
    {
        if (material != null)
        {
            offset.x += scrollSpeed * Time.deltaTime;
            // 스크린샷의 셰이더가 URP Lit이므로 텍스처 속성 이름은 _BaseMap 입니다.
            material.SetTextureOffset("_BaseMap", offset);
        }
    }
}
