using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Helpers.Extensions
{
    public static class MappingHelperExtension
    {
        public static void Assign<TTarget, TSource>(this TTarget target, TSource source) where TTarget : new()
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException("Target or Source cannot be null");
            }

            Type typeTarget = typeof(TTarget);
            Type typeSource = typeof(TSource);
            foreach (PropertyInfo propertyTarget in typeTarget.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyTarget.CanWrite)
                {
                    PropertyInfo? propertySource = typeSource.GetProperty(propertyTarget.Name);
                    object? value = null;
                    if (propertySource != null)
                    {
                        value = propertySource.GetValue(source, null);
                    }

                    if (value != null)
                    {
                        propertyTarget.SetValue(target, value, null);
                    }
                }
            }
        }

        // Método existente para mapear propiedades de un objeto a otro
        public static TTarget? MapPropertiesTo<TTarget>(this object? source) where TTarget : new()
        {
            TTarget? target = default;

            if (source == null) return target;
            target = (TTarget?)Activator.CreateInstance(typeof(TTarget));
            if (source == null || target == null) throw new ArgumentNullException("Source or/and Target cannot be null");

            var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var targetProperties = typeof(TTarget).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite);

            foreach (var sourceProp in sourceProperties)
            {
                var targetProp = targetProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);
                if (targetProp != null)
                {
                    var value = sourceProp.GetValue(source, null);
                    targetProp.SetValue(target, value, null);
                }
            }

            return target;
        }

        // Nuevo método para mapear colecciones de objetos
        public static IEnumerable<TTarget> MapCollectionTo<TSource, TTarget>(this IEnumerable<TSource> sourceCollection) where TTarget : new()
        {
            var resultList = new List<TTarget>();

            if (sourceCollection == null) throw new ArgumentNullException(nameof(sourceCollection));

            foreach (var sourceItem in sourceCollection)
            {
                var targetItem = sourceItem.MapPropertiesTo<TTarget>();
                if (targetItem != null)
                    resultList.Add(targetItem);
            }

            return resultList;
        }
    }
}
