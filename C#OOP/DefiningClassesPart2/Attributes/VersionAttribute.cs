namespace Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
        AttributeTargets.Enum, AllowMultiple = false)]
    [Version (1,5)]
    public class VersionAttribute : Attribute
    {
        public int Major { get; private set; }

        public int Minor { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public override string ToString()
        {
            return string.Format("Version: {0}.{1}", this.Major, this.Minor);
        }
    }
}
