using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindHeros : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image[] _rightHerosImages;
    [SerializeField] private Transform _parentHeros;
    [SerializeField] private int _countHeros = 50;
    private List<Hero> _heroes = new List<Hero>();
    private List<int> _rightIdHeros = new List<int>();

    private void Start()
    {
        GetRandomRightHero(_rightHerosImages.Length);

        for (int i = 0; i < _countHeros; i++)
        {
            GameObject heroGO = new GameObject();
            heroGO.transform.parent = _parentHeros;

            Image image = heroGO.AddComponent<Image>();
            Hero hero = heroGO.AddComponent<Hero>();

            image.sprite = _sprites[0];
            hero.Init(i, _sprites[0]);
            hero.OnClicked += OnHeroClick;

            _heroes.Add(hero);
        }

        for (int i = 0; i < _rightHerosImages.Length; i++)
        {
            for (int w = 0; w < _rightIdHeros.Count; w++)
            {
                _rightHerosImages[i].sprite = _heroes[_rightIdHeros[w]].HeroIcon;
            }
            
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _heroes.Count; i++)
        {
            _heroes[i].OnClicked -= OnHeroClick;
        }
    }

    private void OnHeroClick(int id)
    {
        if (_rightIdHeros.Contains(id))
        {
            Debug.Log("Правильно");
        }
        else
        {
            Debug.Log("Не правильно");
        }
    }

    private void GetRandomRightHero(int count = 3)
    {
        for (int i = 0; i < count; i++)
        {
            _rightIdHeros.Add(Random.Range(0, _countHeros));
        }
    }

}
