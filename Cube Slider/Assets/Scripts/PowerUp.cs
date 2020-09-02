using System.Collections;

using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speedChange;
    private float normalize;
    private double rtSpeed;

    public ParticleSystem Sistem1;
    public ParticleSystem Sistem2;

    public PlayerMovement movement;

    private void Awake()
    {
        if (Sistem1.isPlaying == true || Sistem2.isPlaying == true)
        {
            Sistem1.Pause();
            Sistem2.Pause();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlowDown"))
        {


            speedChange = 0.5f;
            normalize = 2f;
            movement.forwardForce = movement.forwardForce * speedChange;
            Destroy(other.transform.parent.gameObject);
            StartCoroutine("waitTime");
        }
        if (other.CompareTag("SpeedUp"))
        {
            speedChange = 2f;
            normalize = 0.5f;
            movement.forwardForce = movement.forwardForce * speedChange;
            Destroy(other.transform.parent.gameObject);
            Sistem1.Play();
            Sistem2.Play();
            StartCoroutine("waitTime");
        }

    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
        movement.forwardForce = movement.forwardForce * normalize;

        if (Sistem1.isPlaying == true || Sistem2.isPlaying == true)
        {
            Sistem1.Clear();
            Sistem2.Clear();
            Sistem1.Pause();
            Sistem2.Pause();
        }

    }
}
