using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomTutorial
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform m_playerPosition;
        public float lerpSpeed = 1.0f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (m_playerPosition == null) return;

            offset = transform.position - m_playerPosition.position;
        }

        private void Update()
        {
            if (m_playerPosition == null) return;

            targetPos = m_playerPosition.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
