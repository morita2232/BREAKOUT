using UnityEngine;

public class PowerUpVerde : MonoBehaviour
{
    public MovimientoPelota _pelota;
    public GameManager _manager;
    [SerializeField] private float spreadAngle = 30f;

    private void Start()
    {
        if (_pelota == null) _pelota = FindObjectOfType<MovimientoPelota>();
        if (_manager == null) _manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pala")) return;
        if (_pelota == null || _manager == null) return;

        float originalSpeed = 10f; 
        if (_pelota.TryGetComponent<Rigidbody2D>(out var originalRb))
        {
            originalSpeed = originalRb.velocity.magnitude;
        }

        CreateBall(0f, originalSpeed);      
        CreateBall(-spreadAngle, originalSpeed);
        CreateBall(spreadAngle, originalSpeed); 

        _manager.life += 3;
        Destroy(gameObject);
    }

    private void CreateBall(float angleOffset, float speed)
    {
        float angle = 90f + angleOffset;
        Vector2 direction = new Vector2(
            Mathf.Sin(angle * Mathf.Deg2Rad),
            Mathf.Cos(angle * Mathf.Deg2Rad)
        ).normalized;

        Vector2 spawnOffset = direction * 0.3f;
        Vector3 spawnPos = _pelota.center + new Vector3(spawnOffset.x, spawnOffset.y, 0);

        GameObject newBall = Instantiate(_pelota.powerball[2], spawnPos, Quaternion.identity);

        if (newBall.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = direction * speed;
        }
    }
}
