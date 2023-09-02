//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public interface ILocalEventProvider
//{

//}

//public class ProviderTest : ProviderTest.IEventProvider
//{
//    #region Delegates

//    public delegate void CombatObjectDelegate(int i);

//    #endregion

//    #region EventProvider

//    public interface IEventProvider : ILocalEventProvider
//    {
//        event CombatObjectDelegate Activated;
//        event CombatObjectDelegate BeginDeactivate;

//        void OnActivated(int i);
//        void OnBeginDeactivate(int i);
//    }

//    #endregion

//    #region Events

//    public event CombatObjectDelegate Activated;
//    public event CombatObjectDelegate BeginDeactivate;

//    #endregion

//    #region Methods

//    public void OnActivated(int i)
//    {
//        Activated?.Invoke(i);
//    }
//    public void OnBeginDeactivate(int i)
//    {
//        BeginDeactivate?.Invoke(i);
//    }

//    #endregion
//}

//public class Test
//{
//    LocalObjectEvents_NEW localEvents;

//    private void Whatever()
//    {
//        localEvents.GetEventProvider<ProviderTest.IEventProvider>().Activated += Test_Activated;
//        localEvents.GetEventProvider<ProviderTest.IEventProvider>().BeginDeactivate += Test_Activated;

//        localEvents.GetEventProvider<ProviderTest.IEventProvider>().OnActivated(1);
//    }

//    private void Test_Activated(int huh)
//    {
//        Debug.Log(huh);
//    }
//}

//public interface ILocalEventsDependant_NEW
//{
//    void InitializeLocalEvents(LocalObjectEvents_NEW localEvents);
//}
//public class LocalObjectEvents_NEW : MonoBehaviour
//{
//    private Dictionary<Type, ILocalEventProvider> eventProviders;

//    private void Awake()
//    {
//        eventProviders = new Dictionary<Type, ILocalEventProvider>();

//        var allComponents = gameObject.GetAllComponents<ILocalEventProvider>();
//        for (int i = 0; i < allComponents.Count; i++)
//        {
//            var c = allComponents[i];
//            var t = c.GetType();

//            if (eventProviders.ContainsKey(t))
//                eventProviders.Add(t, c);
//        }
//    }

//    public T GetEventProvider<T>() where T : class, ILocalEventProvider
//    {
//        if (eventProviders.TryGetValue(typeof(T), out var result))
//        {
//            return (T)result;
//        }

//        return null;
//    }
//}
