namespace ThreeDimensionalBody
{
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
            return Math.Round( mass, 3 );
        }

        public override double GetVolume()
        {
            if ( _bodies.Count == 0 )
            {
                return 0;
            }
            var volumes = _bodies.Sum( c => c.GetVolume() );
            return Math.Round( volumes, 3 );
        }

        public override double GetDensity()
        {
            if ( _bodies.Count == 0 )
            {
                return 0;
            }
            var densitys = GetMass() / GetVolume();
            return Math.Round( densitys, 3 );
        }

        private bool HasParent( Body body )
        {
            if ( body == null )
            {
                return true;
            }

            if ( Equals( body ) )
            {
                return true;
            }

            Compound? parent = Parent;
            while ( parent != null )
            {
                if ( ReferenceEquals( parent, body ) )
                {
                    return true;
                }
                parent = parent.Parent;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Составное тело. {base.ToString()}[{string.Join( ", ", _bodies )}]";
        }
    }
}