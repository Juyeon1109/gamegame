using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwwner : MonoBehaviour
{

    public GameObject bulletprefab;     //생성할 탄알의  원본 프리팹 
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private Transform target;
    private float spawnRate = 0;
    private float timeAfterSpawn;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 잏의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0;
        //탄알 생성격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindAnyObjectByType<Playercontroller1>().transform;

        AudioSource = GetComponent<AudioSource>();
    }

   void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 지점에서부터 누적된 시간이 주기보다 크거나 같다면
        if (timeAfterSpawn > spawnRate)
        {
            //누락된 시간을 리셋
            timeAfterSpawn = 0f;

            //bulletPrefab의 복제본을 
            //transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletprefab, transform.position, transform.rotation);

            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            AudioSource.Play();
        }
    }
}