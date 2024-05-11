using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/* Based on the below, with minor modifications and deletions
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Shooter.cs?ref_type=heads
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class ShooterController : MonoBehaviour
{
    [Header("Speed and Projectile Lifespan")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10f;
    [SerializeField] float lifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;

    [Header("Firing Variance")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

  readonly bool _isFiring = true;
    Coroutine _firingCoroutine;
    Transform _target;
    AudioPlayer _audioPlayer;
    GameObject _spaceCat;

    void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        _spaceCat = GameObject.FindWithTag("SpaceCat");
        _target = _spaceCat.transform;
    }

    void FixedUpdate()
    {
        if (_target != null)
        {
            FireProjectiles();
        }
        else
        {
            return;
        }
    }

    void FireProjectiles()
    {
        if (_isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!_isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(_target.position.x, _target.position.y, 90));

            if (instance.TryGetComponent<Rigidbody2D>(out
                var _body))
            {
                _body.velocity = transform.right * speed;
            }

            Destroy(instance, lifeTime);

            float timeToNextProjectile = Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            _audioPlayer.PlayLaserClip();

            yield
            return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
