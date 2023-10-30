using UnityEngine;

namespace _Games._Scripts.Weapons
{
    public class DoubleSword : MonoBehaviour
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
            if (other.CompareTag(ConstTags.ENEMY_TAG))
            {
                characterController.OnHitted(other.GetComponent<CharacterController>());
            }
        }
    }
}