// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using SDF.Business.Implementations;
using SDF.Infrastructure;
using SDF.Infrastructure.Interfaces;


var services = new ServiceCollection()
    .CreateInfrastructureDependencies()
    .BuildServiceProvider();

var quoteService = new QuoteService(services.GetService<IQuoteRepository>()!);
var quotes = quoteService.GetQuotes();
quotes.ForEach(Console.WriteLine);
