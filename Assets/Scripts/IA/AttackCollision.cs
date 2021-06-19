using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour {

    public int Damage = 5;

    public float ZoneDamage = 1f;

    public float timer;

    public HealthManager hm;

    public MannequinScript MannequinScript;

    public AudioSource AudioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        hm = GameObject.Find("Player").GetComponent<HealthManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
            MannequinScript.isAttack = true;
            AudioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            AudioSource.Play();

            if (timer <= -1.0f)
            {
                timer = (0);
                hm.Health = hm.Health - Damage;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ZoneDamage);
    }
}
