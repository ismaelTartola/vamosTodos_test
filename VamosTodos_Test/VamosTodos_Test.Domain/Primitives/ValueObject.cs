namespace VamosTodos_Test.Domain.Primitives;

public abstract record ValueObject : IEquatable<ValueObject>
{
    /// <inheritdoc />
    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(default(HashCode), (hashCode, obj) =>
            {
                hashCode.Add(obj.GetHashCode());

                return hashCode;
            }).ToHashCode();

    /// <summary>
    /// Gets the atomic values of the value object.
    /// </summary>
    /// <returns>The collection of objects representing the value object values.</returns>
    protected abstract IEnumerable<object> GetAtomicValues();
}