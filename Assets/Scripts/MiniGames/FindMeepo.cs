using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindMeepo : MonoBehaviour
{
    [SerializeField] private Sprite _meepoSprite;
    [SerializeField] private Transform _parentHeros;
    [SerializeField] private int _countHero;
    private int _rightMeepoId;
    private List<Hero> _heroes = new List<Hero>();

    private void Start()
    {
        RandomIdRightMeepo();

        for (int i = 0; i < _countHero; i++)
        {
            GameObject heroGO = new GameObject();
            heroGO.transform.parent = _parentHeros;

            Image image = heroGO.AddComponent<Image>();
            Hero hero = heroGO.AddComponent<Hero>();

            image.sprite = _meepoSprite;
            hero.Init(i);
            hero.OnClicked += OnHeroClick;

            _heroes.Add(hero);
        }
    }

    private void OnHeroClick(int id)
    {
        if (_rightMeepoId == id)
        {
            Debug.Log("Правильно");
        }
        else
        {
            Debug.Log("Не правильно");
        }
    }

    private void RandomIdRightMeepo()
    {
        _rightMeepoId = Random.Range(0, _countHero);
    }
}
