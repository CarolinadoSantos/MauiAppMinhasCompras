
namespace MauiAppMinhasCompras.Views
{
    internal class Converter
    {
        internal static double ToDouble(string text)
        {
            if (double.TryParse(text, out double valor))
                return valor;

            return 0;
        }
    }
}