using System;
using System.Collections.Generic;

namespace IoC
{
    public static class IoC
    {
        private static Dictionary<Type, Type> singleTones = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> scopes = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> transients = new Dictionary<Type, Type>();


        #region Registration of DI
        public static void AddSingleton<TAbstraction, TImplementation>()
        {
            var key = typeof(TAbstraction);

            if (!singleTones.ContainsKey(key))
                singleTones.Add(key, typeof(TImplementation));
        }

        public static void AddScopped<TAbstraction, TImplementation>()
        {
            var key = typeof(TAbstraction);

            if (!scopes.ContainsKey(key))
                scopes.Add(key, typeof(TImplementation));
        }

        public static void AddTransient<TAbstraction, TImplementation>()
        {
            var key = typeof(TAbstraction);
            if (!transients.ContainsKey(key))
                transients.Add(key, typeof(TImplementation));
        }
        #endregion

        public static Dictionary<Type, Type> GetSingletons()
        {
            return singleTones;
        }

        public static Dictionary<Type, Type> GetScopes()
        {
            return scopes;
        }

        public static Dictionary<Type, Type> GetTransinets()
        {
            return transients;
        }
    }
}
