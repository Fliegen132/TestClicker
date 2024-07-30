using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CoinBehaviur : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void AddForce()
    {
        Vector2 force = new Vector2(Random.Range(-5, 5), Random.Range(5, 10));
        _rigidbody.AddForce(force, ForceMode2D.Impulse);

        float spin = Random.Range(-600, 600); 
        _rigidbody.angularVelocity = spin;
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

}
