using UnityEngine;

public class FireworksOnDemandControl : MonoBehaviour
{
    public AudioClip[] Launch;
    public AudioClip[] Explosion;

    private AudioSource launchSource;
    private AudioSource explosionSource;

    void Start()
    {
        // todo: would generally be nice to also have a 'sound travel' delay to both launch and explosion...

        // find a launch sound, create and fire immediately
        if(Launch.Length > 0)
        {
            var launchClip = Launch[Random.Range(0, Launch.Length)];
            launchSource = CreateAudio(launchClip);

            launchSource.Play();
        }

        // find an explosion sound, create and fire delayed
        if (Explosion.Length > 0)
        {
            var explosionClip = Explosion[Random.Range(0, Launch.Length)];
            explosionSource = CreateAudio(explosionClip);

            //1.1 is halfway between 1.0 and 1.2 rocket particle lifespans... eventually would be nice to control this by parameter (calc random, set vfx and play delayed here...)
            explosionSource.PlayDelayed(1.1f);  
        }

        // schedule our destruction once explosion compeltely over
        Destroy(gameObject, 10f);
    }

    private AudioSource CreateAudio(AudioClip clip)
    {
        var source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.spatialBlend = 1f;  // to enable sound fall off from camera
        source.minDistance = 10f;  // values to effect falloff (logarithmic) curve
        source.maxDistance = 200f;

        return source;
    }
}
