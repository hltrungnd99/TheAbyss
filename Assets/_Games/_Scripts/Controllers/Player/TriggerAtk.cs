using UnityEngine;

public class TriggerAtk : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private void OnValidate()
    {
        if (!characterController)
        {
            characterController = GetComponentInParent<CharacterController>();
        }
    }

    private void Start()
    {
        if (!characterController)
        {
            characterController = GetComponentInParent<CharacterController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag(ConstTags.ENEMY_TAG) || other.CompareTag(ConstTags.PLAYER_TAG)) &&
            !other.CompareTag(characterController.gameObject.tag))
        {
            characterController.countTargetCanAtk++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag(ConstTags.ENEMY_TAG) || other.CompareTag(ConstTags.PLAYER_TAG)) &&
            !other.CompareTag(characterController.gameObject.tag))
        {
            characterController.countTargetCanAtk--;
        }
    }
}