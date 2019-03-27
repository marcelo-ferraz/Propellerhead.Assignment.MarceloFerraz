using System;

namespace Propellerhead.Assignment.MarceloFerraz.Core.Commons
{
    public interface ICacheService
    {
        T Get<T>(Func<T> getter, string key);
    }
}