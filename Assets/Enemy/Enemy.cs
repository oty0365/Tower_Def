
using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float hp;
        public float damage;
        public float moveSpeed;
        protected Vector2 _goal;
        protected Vector2 _finalDestination;
        protected int _wayCont;
        [SerializeField] protected GameObject[] wayPoints;
        protected Vector2 _dir;
        protected void SetUpEnemy()
        {
            wayPoints = WayPoints.WayPointMother;
            _finalDestination = wayPoints[wayPoints.Length-1].transform.position;
            _goal = wayPoints[_wayCont + 1].transform.position;
            _wayCont = 0;
            gameObject.transform.position = new Vector2(wayPoints[0].transform.position.x,wayPoints[0].transform.position.y+0.1f);
        }

        protected void MoveToWay()
        {
            if (!gameObject.transform.position.Equals(_goal))
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _goal,
                    moveSpeed * Time.deltaTime);
            }
            else
            {
                if (gameObject.transform.position.Equals(_finalDestination))
                {
                    Destroy(gameObject);
                    return;
                }
                _wayCont++;
                _goal = wayPoints[_wayCont + 1].transform.position;
                _dir = (Vector2)gameObject.transform.position - _goal;
                Debug.Log(Mathf.Atan2(_dir.y, _dir.y));
                
            }
        }
    }
}

