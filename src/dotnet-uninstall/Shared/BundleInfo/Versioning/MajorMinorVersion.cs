﻿using System;
using Microsoft.DotNet.Tools.Uninstall.Shared.Exceptions;
using Microsoft.DotNet.Tools.Uninstall.Shared.Utils;

namespace Microsoft.DotNet.Tools.Uninstall.Shared.BundleInfo.Versioning
{
    internal class MajorMinorVersion : BeforePatch, IEquatable<MajorMinorVersion>, IComparable, IComparable<MajorMinorVersion>
    {
        public MajorMinorVersion(int major, int minor) : base(major, minor) { }

        public static MajorMinorVersion FromInput(string value)
        {
            if (!Regexes.BundleMajorMinorRegex.IsMatch(value) || !Version.TryParse(value, out var version))
            {
                throw new InvalidInputVersionException(value);
            }

            return new MajorMinorVersion(version.Major, version.Minor);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MajorMinorVersion);
        }

        public bool Equals(MajorMinorVersion other)
        {
            return other != null &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as MajorMinorVersion);
        }

        public int CompareTo(MajorMinorVersion other)
        {
            return other == null ? 1 : _version.CompareTo(other._version);
        }
    }
}
