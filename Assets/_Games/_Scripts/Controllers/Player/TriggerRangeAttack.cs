using UnityEngine;

public class TriggerRangeAttack : MonoBehaviour
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
            characterController.WarningAttack(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag(ConstTags.ENEMY_TAG) || other.CompareTag(ConstTags.PLAYER_TAG)) &&
            !other.CompareTag(characterController.gameObject.tag))
        {
            characterController.CancelWarningAttack(other);
        }
    }
}