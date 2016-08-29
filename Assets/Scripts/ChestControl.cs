﻿using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(UseOnPlayerTrigger))]
    public class ChestControl : MonoBehaviour
    {
        public float NumberOfGems = 0f;

        private SpriteAnimator m_animator;
        void Awake()
        {
            m_animator = GetComponent<SpriteAnimator>();
        }

        void OpenChest()
        {
            m_animator.onStop.AddListener(Give);
            m_animator.Play("Open", true);
        }

        void Give()
        {
            m_animator.onStop.RemoveListener(Give);
            m_animator.Play("Opened");
            GameManager.Instance.ChestOpened(NumberOfGems);
        }
    }
}
