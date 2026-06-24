using System;
using UnityEngine;

public class DissolveDriver : MonoBehaviour
{
    public Renderer targetRenderer;

    public string propertyName = "_Dissolve_Amount";

    private int propertyId;

    public float duration = 1.5f;

    public bool pingPong = true;

    private float elapsed;

    private MaterialPropertyBlock block;

    private void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
        block = new();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float amount = pingPong ? Mathf.PingPong(elapsed / duration, 1f) : Mathf.Clamp01(elapsed / duration);

        targetRenderer.GetPropertyBlock(block);
        block.SetFloat(propertyId, amount);
        targetRenderer.SetPropertyBlock(block);
    }
}
