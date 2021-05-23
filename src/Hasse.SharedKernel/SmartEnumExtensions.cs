using Ardalis.SmartEnum;

namespace Hasse.SharedKernel
{
    public static class SmartEnumExtensions
    {
        public static string NormalizeName<T>(this SmartEnum<T> smart) where T : SmartEnum<T, int>
        {
            return smart.Name.Replace("Type", string.Empty);
        }

        public static string PluralizeName<T>(this SmartEnum<T> smart) where T : SmartEnum<T, int>
        {
            return $"{smart.NormalizeName()}s";
        }
    }
}