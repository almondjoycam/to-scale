using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class ResizeableTilemap : MonoBehaviour, IResizeable
{
    TilemapCollider2D tileCollider;
    float scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        tileCollider = GetComponent<TilemapCollider2D>();
    }

    public void Resize(float scaleFactor, float resizeTime)
    {
        Vector3 formerScale = transform.localScale;
        this.scaleFactor = scaleFactor;
        StartCoroutine(ResizeEnumerator(resizeTime, formerScale));
        tileCollider.ProcessTilemapChanges();
    }

    IEnumerator ResizeEnumerator(float resizeTime, Vector3 formerScale)
    {
        for (float t = 0; t < resizeTime; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(
                formerScale,
                formerScale * scaleFactor,
                t / resizeTime
            );
            yield return null;
        }
        yield break;
    }

    public Vector3 ScaledPosition(Vector3 worldPoint)
    {
        return (worldPoint - transform.position) * scaleFactor;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }
}
