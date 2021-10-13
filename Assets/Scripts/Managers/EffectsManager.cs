using UnityEngine;

namespace Tetris.Managers
{
    public class EffectsManager : SingletonInstance<EffectsManager>
    {
        [Header("Particle System Object.")]
        [SerializeField]
        private ParticleSystem particleSystemObj;

        public void PlayParticle(Vector3 position)
        {
            particleSystemObj.transform.position = position;
            particleSystemObj.Play();
        }
    }
}