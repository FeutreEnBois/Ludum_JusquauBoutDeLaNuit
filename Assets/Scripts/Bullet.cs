using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    public Rigidbody2D rb;
    public int playerIndex = 0;
    [SerializeField] int damage = 10;

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Start()
    {
        rb.velocity *= speed;
        transform.Rotate(0.0f, 0.0f, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f);
        StartCoroutine(DestroyBulletAfterTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) return;
        Debug.Log("Bullet touch something");
        Destroy(gameObject);
    }
}
