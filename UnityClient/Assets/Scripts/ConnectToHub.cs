using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using UnityEngine;

public class ConnectToHub : MonoBehaviour
{
    private HubConnectionState _lastConnectionState;
    private HubConnection _connection;

    // Start is called before the first frame update
    void Start()
    {
        var endpoint = new UriEndPoint(new Uri("https://localhost:44340/rfch"));

        MyLoggerFactory loggerFactory = new MyLoggerFactory();
        _connection = new HubConnection(
            new HttpConnectionFactory(new MyOptions(), loggerFactory),
            new JsonHubProtocol(),
            endpoint,
            new MyServiceProvider(),
            loggerFactory);

        _connection.StartAsync().ConfigureAwait(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_connection.State != _lastConnectionState)
        {
            Debug.Log($"Hub connection state changed from {_lastConnectionState} to {_connection.State}");
            _lastConnectionState = _connection.State;
        }
    }

    private class MyOptions : IOptions<HttpConnectionOptions>
    {
        public HttpConnectionOptions Value => new HttpConnectionOptions();
    }

    private class MyLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            // no-op
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return NullLogger.Instance;
        }

        public void Dispose()
        {
            // no-op
        }
    }

    private class MyServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return null;
        }
    }

}
