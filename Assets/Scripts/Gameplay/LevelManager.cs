using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BooleanVariable _isPlayerDead;
    [SerializeField] private BooleanVariable _isPlayerActive;

    // Start is called before the first frame update
    void Awake()
    {
        _isPlayerDead.value = false;
        _isPlayerActive.value = false;
    }
}