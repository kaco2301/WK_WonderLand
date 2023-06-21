using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    [Header("Fire Settings")]
    [SerializeField]
    private GameObject FireEffect;

    [Header("Spawn Points")]
    [SerializeField]
    private Transform casingSpawnPoint;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipFire;    //발포사운드

    [Header("Weapon Setting")]
    [SerializeField]
    private PistolSetting pistolSetting;

    private float lastAttackTime = 0;   //마지막 발사시간 체크

    private AudioSource audioSource;
    private CasingMemoryPool casingMemoryPool;
    //private PlayerAnimatorController animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipFire;
        //animator = GetComponent<PlayerAnimatorController>();
        casingMemoryPool = GetComponent<CasingMemoryPool>();


    }

    private void OnEnable()
    {
        FireEffect.SetActive(false);
    }
    void Start()
    {
        pistolSetting = GetComponent<PistolSetting>();

    }


    void Update()
    {
        
    }

    public void StartWeaponAction(int type = 0)
    {
        if(type == 0)
        {
            OnAttack();
        }
    }

    public void StopWeaponAction(int type = 0)
    {
        if(type ==0)
        {
            StopCoroutine("OnAttackLoop");
        }

    }

    private IEnumerator OnAttackLoop()
    {
        while(true)
        {
            OnAttackLoop();

            yield return null;
        }
    }

    public void OnAttack()
    {
        if(Time.time - lastAttackTime>pistolSetting.attackRate)
        {
            lastAttackTime = Time.time;
            //animator.Play("Fire", -1, 0);

            StartCoroutine("OnFireEffect");
            audioSource.Play();
            casingMemoryPool.SpawnCasing(casingSpawnPoint.position, transform.right);
            

        }
    }

    private IEnumerator OnFireEffect()
    {
        FireEffect.SetActive(true);
        yield return new WaitForSeconds(pistolSetting.attackRate * 0.3f);
        FireEffect.SetActive(false);
    }
}
