using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockback;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<KnockBack>();  
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
        
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0) {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity) ;
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }

    
}
