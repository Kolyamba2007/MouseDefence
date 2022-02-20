using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;

public class CheeseConverterView : TowerView
{
    [SerializeField] private Transform _spawnPoint;

    private Coroutine _coroutine;

    public Vector2 SpawnPoint => _spawnPoint.position;

    public Signal ProduceCheeseSignal { get; } = new Signal();

    private IEnumerator ProducingCheese()
    {
        yield return new WaitForSeconds(TowerData.AttackSpeed);
        while (true)
        {
            ProduceCheeseSignal.Dispatch();

            yield return new WaitForSeconds(TowerData.AttackSpeed);
        }
    }

    public void StartProducing()
    {
        _coroutine = StartCoroutine(ProducingCheese());
    }

    public void StopProducing()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
