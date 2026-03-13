using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public GameObject particlePrefab;

    public int numberParticles = 10;
    public float initialVelocity = 5f;
    public float initialAngle = 45f;
    public float lifeTime = 3f;
    public float gravity = 9.8f;

    public List<GameObject> particles = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateParticleExplosion();
        }

        for (int i = particles.Count - 1; i >= 0; i--)
        {
            Particle p = particles[i].GetComponent<Particle>();

            UpdateParticlePosition(p, Time.deltaTime);

            if (p.activeTime > p.maxLifeTime)
            {
                Destroy(particles[i]);
                particles.RemoveAt(i);
            }
        }
    }

    void CreateParticleExplosion()
    {
        for (int i = 0; i < numberParticles; i++)
        {
            GameObject newParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            Particle p = newParticle.GetComponent<Particle>();

            p.initialVelocity = Random.Range(initialVelocity * 0.5f, initialVelocity * 1.5f);
            p.initialAngle = initialAngle;
            p.maxLifeTime = Random.Range(lifeTime * 0.5f, lifeTime * 1.5f);
            p.gravity = gravity;

            p.activeTime = 0f;
            p.startPosition = transform.position;

            particles.Add(newParticle);
        }
    }

    void UpdateParticlePosition(Particle p, float time)
    {
        p.activeTime += time;

        float angleRad = p.initialAngle * Mathf.Deg2Rad;

        float x = p.initialVelocity * Mathf.Cos(angleRad) * p.activeTime;
        float y = p.initialVelocity * Mathf.Sin(angleRad) * p.activeTime - 0.5f * p.gravity * p.activeTime * p.activeTime;

        p.transform.position = p.startPosition + new Vector3(x, y, 0);
    }
}
