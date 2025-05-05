using System.Collections;
using UnityEngine;

public class 
    Moneda : MonoBehaviour
{
    public float disappearDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CollectCoin());
        }
    }

    private IEnumerator CollectCoin()
    {

        yield return new WaitForSeconds(disappearDelay);


        gameObject.SetActive(false);
    }
}