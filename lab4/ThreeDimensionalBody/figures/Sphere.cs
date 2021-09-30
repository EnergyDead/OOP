﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalBody.figures
{
    public class Sphere : SolidBody
    {
        private double _radius;
        public Sphere( double radius, double density ) : base ( density )
        {
            SetRadius( radius );
            SetVolume();
        }

        public double GetRadius()
        {
            return _radius;
        }

        public override string ToString()
        {
            return $"Сфера\nМасса: {GetMass()}\nОбъем: {GetVolume()}\nПлотность: {GetDensity()}";
        }

        protected override void SetVolume()
        {
            _volume = 4 * Math.PI * Math.Pow( _radius, 3 ) / 3;
        }

        private void SetRadius( double value )
        {
            _radius = value;
        }
    }
}
