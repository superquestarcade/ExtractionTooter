using Player;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPlus
{
    [SerializeField] private PlayerCharacter playerPrefab;

    private PlayerCharacter playerCharacter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCharacter = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
