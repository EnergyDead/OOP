using System.Text;

namespace ThreeDimensionalBody
{
    public class Compound : Body
    {
        private List<Body> _bodies;

        public Compound()
        {
            _bodies = new List<Body>();
        }

        public bool AddChildBody( Body body )
        {
            if ( body == null )
            {
                return false;
            }

            if ( Equals( body ) )
            {
                return false;
            }

            if ( HasEquals( body ) )
            {
                return false;
            }

            _bodies.Add( body );

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

        public bool Contains( Body body )
        {
            return _bodies.Contains( body );
        }

        public bool HasEquals( Body body )
        {
            if ( body is Compound )
            {
                if ( ( body as Compound ).Contains( this ) )
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"Составное тело. {base.ToString()}[{string.Join(", ", _bodies )}]";
        }
    }
}