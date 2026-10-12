using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : IServiceLocator
{
    private readonly Dictionary<Type, object> _services = new();

    public void Register<T>(T service) where T : class
        => _services[typeof(T)] = service;

    public T GetService<T>() where T : class
    {
        if (_services.TryGetValue(typeof(T), out var s))
            return s as T;

        Debug.LogError($"[ServiceLocator] {typeof(T).Name} not registered");
        return null;
    }
}