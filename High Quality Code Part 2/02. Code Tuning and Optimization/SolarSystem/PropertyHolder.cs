using System.Windows;

namespace Surfaces
{
    public class PropertyHolder<TPropertyType, THoldingType> where THoldingType:DependencyObject
    {
        DependencyProperty property;

        public PropertyHolder(string name, TPropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            this.property = 
                DependencyProperty.Register(
                    name, 
                    typeof(TPropertyType), 
                    typeof(THoldingType), 
                    new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property
        {
            get { return this.property; }
        }

        public TPropertyType Get(THoldingType obj)
        {
            return (TPropertyType)obj.GetValue(this.property);
        }

        public void Set(THoldingType obj, TPropertyType value)
        {
            obj.SetValue(this.property, value);
        }
    }
}
