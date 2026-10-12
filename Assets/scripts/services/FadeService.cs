using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeService : IFadeService
{
    public async Task FadeIn(Image image, float duration)
    {
        image.gameObject.SetActive(true);
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, 0f);
        await image.DOFade(1f, duration).AsyncWaitForCompletion();
    }

    public async Task FadeOut(Image image, float duration)
    {
        await image.DOFade(0f, duration).AsyncWaitForCompletion();
        image.gameObject.SetActive(false);
    }
}