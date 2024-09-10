using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameItems
{
    public class Saw : MonoBehaviour
    {
        [SerializeField] private Transform _direction;
        [SerializeField] private float _speed;
        [SerializeField] private AudioSource _destroySound;
        private CircleCollider2D _boxCollider;
        private SpriteRenderer _sawImage;

        public static Action<Vector3> OnSpawnBonus;
        public static Action OnIncreaseScore;

        private void Start()
        {
            _boxCollider = GetComponent<CircleCollider2D>();
            _sawImage = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.Lerp(transform.position, _direction.transform.position, Time.deltaTime  * _speed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("HorizontalWall"))
                ChangeDirection(180);
            else if (collision.gameObject.CompareTag("VerticalWall"))
                ChangeDirection(360);
            else if (collision.gameObject.CompareTag("UpperWall"))
                Destroy(gameObject);
        }

        private void ChangeDirection(float offset)
        {
            transform.rotation = Quaternion.Euler(0, 0, offset - transform.localEulerAngles.z);
        }

        public void CollapseReady()
        {
            _sawImage.color = Color.green;
        }

        public void Collapse()
        {
            StartCoroutine(DoCollapse());            
        }

        private IEnumerator DoCollapse()
        {
            _destroySound.Play();
            _boxCollider.enabled = false;
            _sawImage.color = new Color(0f, 0f, 0f, 0f);
            OnSpawnBonus?.Invoke(transform.position);
            OnIncreaseScore?.Invoke();

            while(_destroySound.isPlaying)
            {
                yield return new WaitForSeconds(0.2f);
            }

            Destroy(gameObject);
        }
    }
}

