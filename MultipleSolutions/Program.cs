﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using MultipleSolutions.Handlers;
using MultipleSolutions.Implementations;
using MultipleSolutions.Interfaces;
using MultipleSolutions.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDataReaderFile, FileDataReader>()
            .AddSingleton<IDataParser<Person>, JsonDataParser<Person>>()
            .AddSingleton<IDuplicateFinder<Person, int>, PersonDuplicateFinder>()
            .AddTransient<DuplicateIdentifier>()
            .BuildServiceProvider();

        var duplicateIdentifier = serviceProvider.GetRequiredService<DuplicateIdentifier>();
        duplicateIdentifier.GetDuplicateItems();

    }

  
}