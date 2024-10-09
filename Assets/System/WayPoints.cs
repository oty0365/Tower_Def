using Unity.VisualScripting;
using UnityEngine;

namespace System
{
    public class WayPoints : MonoBehaviour
    {
        public static GameObject[] WayPointMother;

        private void Awake()
        {
            WayPointMother = new GameObject[gameObject.transform.childCount];
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                WayPointMother[i] = gameObject.transform.GetChild(i).gameObject;
            }
        }
    }
}
