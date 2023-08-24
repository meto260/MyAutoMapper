using System.Reflection;

public static class MyAutoMapper {
    /// <summary>
    /// Source object convert to target object
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    /// <param name="source">Source object</param>
    /// <exception cref="NullReferenceException">Source object cannot be null</exception>
    public static T Map<T>(this object source) where T : class, new() {
        if (source == null)
            throw new NullReferenceException("'MyAutoMapper.Map' source should be declarated");

        var TargetProps = typeof(T)
            .GetProperties()
            .Where(pi => pi.CanWrite && !pi.GetIndexParameters().Any())
            .ToDictionary(pi => pi.Name.ToLower());

        T obj = new T();
        foreach (var sprop in source.GetType().GetProperties()) {
            string name = sprop.Name.ToLower();
            dynamic val = GetPropValue(source, name);
            PropertyInfo prop = null;
            if (val != null &&
                TargetProps.TryGetValue(name, out prop) &&
                prop?.PropertyType.IsAssignableFrom(val.GetType())) {
                prop?.SetValue(obj, val);
            }
        }
        return obj;
    }

    /// <summary>
    /// Create a dictionary object from source object
    /// </summary>
    /// <param name="source">Source object</param>
    /// <exception cref="NullReferenceException">Source object cannot be null</exception>
    public static Dictionary<string, dynamic> Create(this object source) {
        if (source == null)
            throw new NullReferenceException("'MyAutoMapper.Create' source should be declarated");

        var instance = new Dictionary<string, dynamic>();
        foreach (var sprop in source.GetType().GetProperties()) {
            string name = sprop.Name.ToLower();
            dynamic val = GetPropValue(source, name);
            instance.Add(name, val);
        }
        return instance;
    }


    private static object GetPropValue(object source, string propertyName) {
        var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
        return property?.GetValue(source);
    }
}