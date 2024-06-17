using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwwner : MonoBehaviour
{

    public GameObject bulletprefab;     //������ ź����  ���� ������ 
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private Transform target;
    private float spawnRate = 0;
    private float timeAfterSpawn;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //�ֱ� ���� ���� ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0;
        //ź�� �������� spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindAnyObjectByType<Playercontroller1>().transform;

        AudioSource = GetComponent<AudioSource>();
    }

   void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn > spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            //bulletPrefab�� �������� 
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletprefab, transform.position, transform.rotation);

            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            AudioSource.Play();
        }
    }
}