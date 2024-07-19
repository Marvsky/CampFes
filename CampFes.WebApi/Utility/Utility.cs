using System.Reflection;

namespace CampFes.WebApi.Utility
{
    public static class Utility
    {
        /// <summary>
        /// 檢索常數值
        /// </summary>
        /// <param name="constantsClass"></param>
        /// <param name="constantName"></param>
        /// <returns></returns>
        public static string? GetConstantValue(Type constantsClass, string constantName)
        {
            FieldInfo? fieldInfo = constantsClass.GetFields(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(f => f.Name == constantName);

            if (fieldInfo == null)
            {
                return constantName;
            }
            return (string?)fieldInfo.GetValue(null);
        }
    }
}
