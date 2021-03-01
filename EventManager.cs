using System;
using System.Collections.Generic;

public class EventManager{

    protected static Dictionary<string, Action<Object>> eventActionDictionary;
    protected static Dictionary<string, Func<Object, Object>> eventFuncDictionary;
    
    protected static EventManager instance;

    public static EventManager Instance {

        get {

            Initialized();
            return instance;

        }

    }

    protected static void Initialized() {

        if (instance == null) {

            instance = new EventManager();
            eventActionDictionary = new Dictionary<string, Action<Object>>();
            eventFuncDictionary = new Dictionary<string, Func<Object, Object>>();
           
        }

    }

    public void AddListener(string eventName, Action<Object> action) {

        Action<Object> auxiliarAction = null;

        if (eventActionDictionary.TryGetValue(eventName, out auxiliarAction)) {

            auxiliarAction += action;
            eventActionDictionary[eventName] = auxiliarAction;

        } else {

            auxiliarAction += action;
            eventActionDictionary.Add(eventName, auxiliarAction);

        }

    }

    public void AddListener(string eventName, Func<Object, Object> function) {

        Func<Object, Object> auxiliarFunc = null;

        if (eventFuncDictionary.TryGetValue(eventName, out auxiliarFunc)) {

            auxiliarFunc += function;
            eventFuncDictionary[eventName] = auxiliarFunc;

        } else {

            auxiliarFunc += function;
            eventFuncDictionary.Add(eventName, auxiliarFunc);

        }

    }

    public void RemoveListener(string eventName, Action<Object> action) {
        
        if (instance == null) {

            return;

        } else {

            Action<Object> auxiliarAction = null;

            if (eventActionDictionary.TryGetValue(eventName, out auxiliarAction)) {

                auxiliarAction -= action;

                if (auxiliarAction != null) {

                    eventActionDictionary[eventName] = auxiliarAction;

                } else {

                    eventActionDictionary.Remove(eventName);

                }

            }

        }
        
    }

    public void RemoveListener(string eventName, Func<Object, Object> function) {
        
        if (instance == null) {

            return;

        } else {

            Func<Object, Object> auxiliarFunction = null;

            if (eventFuncDictionary.TryGetValue(eventName, out auxiliarFunction)) {

                auxiliarFunction -= function;

                if (auxiliarFunction != null) {

                    eventFuncDictionary[eventName] = auxiliarFunction;

                } else {

                    eventFuncDictionary.Remove(eventName);

                }

            }

        }
        
    }

    public Object TriggerListener(string eventName, Object args) {

        if (eventName.Contains("ReturnValue")) {

            Func<Object, Object> auxiliarFunction;

            if (eventFuncDictionary.TryGetValue(eventName, out auxiliarFunction)) {

                return auxiliarFunction.Invoke(args);

            } 

        } else {

            Action<Object> auxiliarAction;

            if (eventActionDictionary.TryGetValue(eventName, out auxiliarAction)) {

                auxiliarAction.Invoke(args);

            }

        }

        return null;

    }
    
}
