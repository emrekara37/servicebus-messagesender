using System;
using Ardalis.GuardClauses;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBus.MessageSender.Lib
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ServiceBusAttribute : FromServicesAttribute
    {

        public ServiceBusAttribute([NotNull] string queueOrTopicName, [NotNull] string connection)
        {
            ServiceBusConfiguration.Connection = Guard.Against.NullOrEmpty(connection, nameof(connection));
            ServiceBusConfiguration.QueueOrTopicName = Guard.Against.NullOrEmpty(queueOrTopicName, nameof(queueOrTopicName));
        }

    }
}