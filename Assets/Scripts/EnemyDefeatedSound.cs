using UnityEngine;

public class EnemyDefeatedSound : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerRef.OnEnemyDefeated.AddListener(unused => PlaySound());
    }

    void PlaySound()
    {
        source.PlayOneShot(clip);
    }
}
