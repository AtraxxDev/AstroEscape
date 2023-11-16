using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad de desplazamiento del tiling en X
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtener el SpriteRenderer adjunto al GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Asegurarse de que el SpriteRenderer tiene un material instanciado (no compartido)
        if (!spriteRenderer.material.HasProperty("_MainTex"))
        {
            Debug.LogError("El material del SpriteRenderer no tiene una textura principal (_MainTex).");
            return;
        }
    }

    void Update()
    {
        // Mover el tiling en X en función del tiempo
        float offset = Time.time * speed;
        Vector2 offsetVector = new Vector2(offset, 0f);

        // Aplicar el desplazamiento al material del SpriteRenderer
        spriteRenderer.material.SetTextureOffset("_MainTex", offsetVector);
    }
}
