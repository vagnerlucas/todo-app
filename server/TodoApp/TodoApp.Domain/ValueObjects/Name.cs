using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.ValueObjects
{
    public class Name
    {
        private string _text;
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new InvalidValueException("O objeto precisa ter um nome");

            _text = text;
        }

        public string ToUpper()
        {
            return _text.ToUpper();
        }

        public static implicit operator Name(string text)
        {
            return new Name(text);
        }

        public static implicit operator string(Name name)
        {
            return name._text;
        }

        public override string ToString()
        {
            return _text;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string value)
            {
                return value == _text;
            }

            return ((Name)obj)._text == _text;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
