using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace PlayerControllers
{
    public class HealthHandler : MonoBehaviour
    {
        public static Action OnDied;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Saw"))
            {
                StartCoroutine(DoDied());
            }
        }

        private IEnumerator DoDied()
        {
            var changeTransform = transform.DOMove(new Vector3(
                transform.position.x - 1.5f, 
                transform.position.y - 3f,
                transform.position.z), 3f);
            var changeRotate = transform.DORotate(new Vector3(0f, 0f, 90f), 1f);
        
            yield return new WaitForSeconds(1f);
            changeTransform.Kill();
            changeRotate.Kill();

            OnDied?.Invoke();
            Destroy(gameObject);
        }
    }
}

