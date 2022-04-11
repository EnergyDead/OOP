namespace ThreeDimensionalBody;

public class Compound : Body
{
    private readonly List<Body> _bodies;
    public Compound()
    {
        _bodies = new List<Body>();
    }

    public bool AddChildBody( Body body )
    {
        if ( HasParent(body) )
        {
            return false;
        }

        _bodies.Add( body );
        // добавить возможность иметь несколько родителей.
        SetRerent( body, this );

        return true;
    }

    public override double GetMass()
    {
        if ( _bodies.Count == 0 )
        {
            return 0;
        }
        double mass = _bodies.Sum( c => c.GetMass() );
        return mass;
    }

    public override double GetVolume()
    {
        if ( _bodies.Count == 0 )
        {
            return 0;
        }
        var volume = _bodies.Sum( c => c.GetVolume() );
        return volume;
    }

    public override double GetDensity()
    {
        if ( _bodies.Count == 0 )
        {
            return 0;
        }
        var density = GetMass() / GetVolume();
        return density;
    }

    private bool HasParent( Body body )
    {
        if ( body == null )
        {
            return true;
        }

        // изменить на ReferenceEquals
        if ( ReferenceEquals( this, body ) )
        {
            return true;
        }

        Queue<Compound> parents = new();
        parents.Enqueue( this );
        while ( parents.Count > 0 )
        {
            Compound? parent = parents.Dequeue();
            if ( ReferenceEquals( parent, body ) )
            {
                return true;
            }
            parent.Parent.ForEach( p =>
            {
                parents.Enqueue( p );
            } );
        }
        return false;
    }

    public override string ToString()
    {
        return $"Составное тело. {base.ToString()}[{string.Join( ", ", _bodies )}]";
    }
}
