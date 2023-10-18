using System;
using UnityEngine;

public class TriggerRangeAttack : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTags.TAG_ENEMY))
        {
            characterController.WarningAttack(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ConstTags.TAG_ENEMY))
        {
            characterController.CancelWarningAttack(other);
        }
    }
}