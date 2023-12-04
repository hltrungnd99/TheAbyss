
using UnityEngine;
using UnityEngine.Events;

namespace _Games._Scripts
{
    public class CallbackAnim : MonoBehaviour
    {
        public UnityEvent[] actions = new UnityEvent[5];

        public void AddCallback(int index, UnityAction callback)
        {
            if (index >= 0 && index < actions.Length)
            {
                actions[index].AddListener(callback);
            }
        }

        public void AddCallbackEndAnim(UnityAction callback)
        {
            if (actions.Length > 0)
            {
                actions[actions.Length - 1].AddListener(callback);
            }
        }

        public void Callback(int index)
        {
            if (index >= 0 && index < actions.Length)
            {
                actions[index]?.Invoke();
            }
        }

        public void CallbackEndAnim()
        {
            if (actions.Length > 0)
            {
                actions[actions.Length - 1]?.Invoke();
            }
        }

        public void RemoveAllCallback()
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].RemoveAllListeners();
            }
        }
    }
}