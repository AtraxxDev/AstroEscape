  using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mt;
    Vector2 offset;
    Transform cam;

    public float speed = 1.0f; // Velocidad de desplazamiento del tiling en X
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private Vector3 initialScale; // Almacena la escala inicial del objeto

    void Start()
    {
        // Obtener el SpriteRenderer adjunto al GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        mt = spriteRenderer.material;
        cam = Camera.main.transform;
        offset = mt.mainTextureOffset;

        // Obtener la cámara principal
        mainCamera = Camera.main;

        // Asegurarse de que el SpriteRenderer tiene un material instanciado (no compartido)
        if (!spriteRenderer.material.HasProperty("_MainTex"))
        {
            Debug.LogError("El material del SpriteRenderer no tiene una textura principal (_MainTex).");
            return;
        }

        // Almacena la escala inicial del objeto
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Mover el tiling en X en función del tiempo
        //float offset = Time.time * speed;
        //Vector2 offsetVector = new Vector2(offset, 0f);

        // Aplicar el desplazamiento al material del SpriteRenderer
        //spriteRenderer.material.SetTextureOffset("_MainTex", offsetVector);

       

        ParallaxOffset();
    }

    private void ParallaxOffset()
    {
        // Ajustar la escala del sprite en función del tamaño ortográfico de la cámara
        float cameraSize = mainCamera.orthographicSize;
        float scale = cameraSize / 5f; // Ajusta el divisor según tu necesidad

        // Multiplica la escala calculada por la escala inicial del objeto
        transform.localScale = new Vector3(initialScale.x * scale, initialScale.y * scale, 1f);


        offset.x = cam.position.x / transform.localScale.x / speed;
        offset.y = cam.position.y / transform.localScale.y / speed;

        mt.mainTextureOffset = offset;
    }
}
