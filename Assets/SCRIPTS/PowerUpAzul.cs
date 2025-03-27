using UnityEngine;

public class PowerUpAzul : MonoBehaviour
{
    private MovimientoPelota _pelota;
    private GameManager _manager;
    private bool _activated = false;

    [Header("Settings")]
    [SerializeField] private int livesPerBall = 1;

    void Start()
    {
        _pelota = FindObjectOfType<MovimientoPelota>();
        _manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_activated || !collision.CompareTag("Pala")) return;
        _activated = true;

        if (_pelota == null || _manager == null) return;

        MovimientoPelota[] originalBalls = FindObjectsOfType<MovimientoPelota>();
        int ballsToCreate = originalBalls.Length;

        foreach (var ball in originalBalls)
        {
            GameObject newBall = Instantiate(
                _pelota.powerball[1],
                ball.transform.position,
                Quaternion.identity
            );

            if (ball.TryGetComponent<Rigidbody2D>(out var originalRb) &&
                newBall.TryGetComponent<Rigidbody2D>(out var newRb))
            {
                newRb.velocity = originalRb.velocity;
            }
        }
        
        _manager.life += ballsToCreate * livesPerBall;

        Destroy(gameObject);
    }
}
