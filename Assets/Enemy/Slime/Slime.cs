using UnityEngine;
namespace Enemy
{
    public class Slime : Enemy
    {
        private void Start()
        {
            SetUpEnemy();
        }

        private void Update()
        {
            MoveToWay();
        }
    }
}
