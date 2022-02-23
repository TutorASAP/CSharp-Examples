// (Declaration)	(Primitive Type)	
public enum Axys : byte
{
	X = 0,
	Y = 1,
	Z = 2
};

// (Declaration)	
public struct Vector3
{
	private float x, y, z;

	public static Vector3 Zero = new Vector3(0,0,0);

	public Vector3(float x, float y, float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public float? GetPosition(Axys axys)
	{
        return axys switch
        {
            Axys.X => x,
            Axys.Y => y,
            Axys.Z => z,
            _ => null,
        };
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector3 vector &&
               x == vector.x &&
               y == vector.y &&
               z == vector.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, z);
    }

    public static bool operator ==(Vector3 left, Vector3 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector3 left, Vector3 right)
    {
        return !(left == right);
    }

}

// (Declaration)
public class Transform
{
    public int ChildCount { get => Childs.Count; }
    public bool hasChanged = false;

    private Vector3 lastPosition = Vector3.Zero;

    public Vector3 position = Vector3.Zero;
    public Vector3 rotation = Vector3.Zero;
    public Vector3 scale = Vector3.Zero;

    private Transform lastParent = null;
    private List<Transform> Childs = new List<Transform>();

    public Transform parent = null;

    public void Update()
    {
        if (hasChanged) hasChanged = false;

        hasChanged = lastPosition != position || lastParent != parent;

        if (!hasChanged) return;

        lastPosition = position;
        lastParent = parent;
    }

    public Transform[] GetChilds()
    {
        if (Childs.Count <= 0) return null;

        return Childs.ToArray();
    }
}


