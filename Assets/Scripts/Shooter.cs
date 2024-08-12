using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = .2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = .2f;

    Coroutine firingCoroutine;
    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    public float GetRandomFiringRate()
    {
        float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
        return Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
    }

    IEnumerator FireContinuosly()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Destroy(instance, projectileLifetime);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(GetRandomFiringRate());
        }
    }
}
