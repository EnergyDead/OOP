namespace ExtensionMethods;

internal static class MyExtensions
{
    public static bool FindMaxEx<T>(this IEnumerable<T> arr, ref T maxV)
    {
        if (!arr.Any())
        {
            return false;
        }

        throw new NotImplementedException();
    }
}
