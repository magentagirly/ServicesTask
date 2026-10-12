using System.Threading.Tasks;
using UnityEngine.UI;

public interface IFadeService
{
    Task FadeIn(Image image, float duration);
    Task FadeOut(Image image, float duration);
}