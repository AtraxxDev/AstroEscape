using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    Material mt;
    public float paralax = 2f;
    Vector2 offset;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        cam = Camera.main.transform;
        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxOffset();
    }

    private void ParallaxOffset()
    {

        offset.x = cam.position.x / transform.localScale.x / paralax;
        offset.y = cam.position.y / transform.localScale.y / paralax;

        mt.mainTextureOffset = offset;
    }
}
