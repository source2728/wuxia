using UnityEngine;
using System.Collections;
using FairyGUI;

namespace Fight
{
    public partial class UI_Character
    {
        public GameObject BodyObject;

        public void InitHp(int max, int cur)
        {
            m_BarHp.max = max;
            m_BarHp.value = cur;
        }

        public void SetHp(int cur)
        {
            m_BarHp.value = cur;
        }
    }
}
