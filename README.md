# EventManager

This script allows for comunication between objects without references


# AddListener

//Activate a listener for a message without value to return

EventManager.Instance.AddListener(string messageToListenFor, Action<object> callback)

//Activate a listener for a message with a value to return

EventManager.Instance.AddListener(string messageToListenFor, Function<object, object> callback)
  
# RemoveListener

//Deactivate a listener for a message without value to return

EventManager.Instance.RemoveListener(string messageToListenFor, Action<object> callback)

//Deactivate a listener for a message with a value to return

EventManager.Instance.RemoveListener(string messageToListenFor, Function<object, object> callback)
  
# TriggerListener

//Send message to the EventManager to process. If the message contains "ReturnValue" the EventManager will send a value in return

EventManager.Instance.TriggerListener(string messageToListenFor)
