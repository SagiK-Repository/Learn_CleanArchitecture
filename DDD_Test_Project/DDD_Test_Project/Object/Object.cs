namespace DDD_Test_Project.Object
{
    public abstract class Object
    {
        protected static bool EqualOperator(Object left, Object right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(Object left, Object right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (Object)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
        public static bool operator ==(Object one, Object two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(Object one, Object two)
        {
            return NotEqualOperator(one, two);
        }
    }

    public class Width<T> : Object where T : struct
    {
        private double _minValue = 0;
        private double _maxValue = 2000;
        private double _value;
        private bool _exceptionSwitch = false;

        public Width() => _value = 0.0;

        public Width(T value)
        {
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(double value)
        {
            ModifyValue(value);
        }
        public Width(T value, T minValue, T maxValue)
        {
            SetMinValue(Convert.ToDouble(minValue));
            SetMaxValue(Convert.ToDouble(maxValue));
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(T value, double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(double value, double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
            ModifyValue(value);
        }

        public void ModifyValue(double value)
        {
            //if(value == null) throw new ArgumentNullException(nameof(value));

            if (value < _minValue)
            {
                _value = _minValue;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            if (value > _maxValue)
            {
                _value = _maxValue;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            _value = value;
        }
        public void SetMinValue(double value)
        {
            if (value > _maxValue) throw new ArgumentException("입력 값이 " + _maxValue.ToString() + "보다 큽니다.");

            if (_value < value)
            {
                _value = value;
                _minValue = value;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _value.ToString() + "보다 작습니다. 임의로 Value값을 조정합니다.");
                return;
            }
            _minValue = value;
        }
        public void SetMaxValue(double value)
        {
            if (value < _minValue) throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다.");

            if (_value > value)
            {
                _value = value;
                _maxValue = value;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _value.ToString() + "보다 큽니다. 임의로 Value값을 조정합니다.");
                return;
            }
            _maxValue = value;
        }
        public void SetMinMaxValue(T minValue, T maxValue)
        {
            SetMinValue(Convert.ToDouble(minValue));
            SetMaxValue(Convert.ToDouble(maxValue));
        }
        public void SetMinMaxValue(double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
        }
        public double GetValue()
        {
            return _value;
        }

        public void SetException(bool eSwitch)
        {
            _exceptionSwitch = eSwitch;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}
