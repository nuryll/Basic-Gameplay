using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private Renderer rend;
    private Vector3 initialScale;
    private float scaleMultiplier = 1.25f; // Ne kadar büyüyüp küçüleceğini belirler.
    private bool isGrowing = true;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        // Başlangıçta renderer bileşenini al
        rend = GetComponent<Renderer>();
        initialScale = transform.localScale;
        StartCoroutine(ChangeProperties());
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    // Bu fonksiyon, objenin rengini rastgele bir renge değiştirir.
    public void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        rend.material.color = new Color(r, g, b);
    }

    IEnumerator ChangeProperties()
    {
        while (true)
        {
            ChangeColor();
            ScaleObject();
            yield return new WaitForSeconds(2); // 2 saniyede bir renk değiştir ve ölçekle.
        }
    }

    void ScaleObject()
    {
        if (isGrowing)
        {
            transform.localScale = initialScale * scaleMultiplier;
            isGrowing = false;
        }
        else
        {
            transform.localScale = initialScale;
            isGrowing = true;
        }
    }
}
