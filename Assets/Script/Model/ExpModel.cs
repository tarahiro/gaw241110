using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241110.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;


namespace gaw241110.model
{
    public class ExpModel : IExpModel
    {
        int exp = 0;
        int level = 1;

        const int c_fakeMaxExp = 100;
        Subject<int> _expUpdated = new Subject<int>();
        Subject<int> _levelUpdated = new Subject<int>();



        public IObservable<int> ExpUpdated => _expUpdated;
        public IObservable<int> LevelUpped => _levelUpdated;
        public int GetMaxExp => c_fakeMaxExp;

        public void InitializeModel(Action<int> expUpdated, Action<int> levelUpped)
        {
            _expUpdated.Subscribe(expUpdated);
            _levelUpdated.Subscribe(levelUpped);

            level = 1;
            exp = 0;
            _levelUpdated.OnNext(level);
            _expUpdated.OnNext(exp);
        }

        public void AddExp(int addedExp)
        {
            exp += addedExp;
            if(addedExp > c_fakeMaxExp)
            {
                exp -= c_fakeMaxExp;
                level++;
                _levelUpdated.OnNext(level);
            }
            _expUpdated.OnNext(exp);
        }
    }
}