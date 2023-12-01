using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    public void ShowHitEffect(Vector2 hitPosition)
    {
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, hitPosition, Quaternion.identity);

            Destroy(effect, 2f); 
        }
    }
}
