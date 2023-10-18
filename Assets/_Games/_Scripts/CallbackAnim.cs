using UnityEngine;
using UnityEngine.Events;

namespace _Games._Scripts
{
    public class CallbackAnim : MonoBehaviour
    {
        [SerializeField] private UnityEvent action1;
        [SerializeField] private UnityEvent action2;
        [SerializeField] private UnityEvent action3;
        [SerializeField] private UnityEvent action4;

        public void AddCallback1(UnityAction callback)
        {
            action1.AddListener(callback);
        }

        public void RemoveCallback1(UnityAction callback)
        {
            action1.RemoveListener(callback);
        }

        public void RemoveAllCallback1()
        {
            action1.RemoveAllListeners();
        }

        public void Callback1()
        {
            action1?.Invoke();
        }

        public void AddCallback2(UnityAction callback)
        {
            action2.AddListener(callback);
        }

        public void RemoveCallback2(UnityAction callback)
        {
            action2.RemoveListener(callback);
        }

        public void RemoveAllCallback2()
        {
            action2.RemoveAllListeners();
        }

        public void Callback2()
        {
            action2?.Invoke();
        }

        public void AddCallback3(UnityAction callback)
        {
            action3.AddListener(callback);
        }

        public void RemoveCallback3(UnityAction callback)
        {
            action3.RemoveListener(callback);
        }

        public void RemoveAllCallback3()
        {
            action3.RemoveAllListeners();
        }

        public void Callback3()
        {
            action3?.Invoke();
        }

        public void AddCallback4(UnityAction callback)
        {
            action4.AddListener(callback);
        }

        public void RemoveCallback4(UnityAction callback)
        {
            action4.RemoveListener(callback);
        }

        public void RemoveAllCallback4()
        {
            action4.RemoveAllListeners();
        }

        public void Callback4()
        {
            action4?.Invoke();
        }
    }
}