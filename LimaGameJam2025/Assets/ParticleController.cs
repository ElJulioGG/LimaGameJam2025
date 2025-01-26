using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleSystems; // Lista de sistemas de partículas

    public void PlayParticles()
    {
        if (particleSystems != null && particleSystems.Length > 0)
        {
            foreach (var particleSystem in particleSystems)
            {
                if (particleSystem != null)
                {
                    particleSystem.Play();
                    Debug.Log("Particle System Play Activado: " + particleSystem.name);
                }
            }
        }
        else
        {
            Debug.LogWarning("No hay sistemas de partículas asignados o la lista está vacía.");
        }
    }
}
