
using System;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

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
        protected Vector2 _dir;
        [SerializeField] protected GameObject[] wayPoints;
        [SerializeField] protected bool canFlip;
        protected float _angle;
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
                if (!canFlip) return;
                _angle = Mathf.Atan2(_goal.y-gameObject.transform.position.y, _goal.x-gameObject.transform.position.x)*(180/Mathf.PI)-90;
                gameObject.transform.rotation = UnityEngine.Quaternion.Euler(0,0,_angle);

            }
        }
    }
}

