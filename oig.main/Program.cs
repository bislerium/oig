using oig.domain.source.faker.Entities;
using oig.pdf;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Diagnostics;

// Faker Setup & Generation
OrderFaker.LineItemCount = 10;
var invoice = InvoiceFaker.Generate();

// File-path setup
var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var fileName = @"invoice.pdf";
var fullPath = Path.Combine(directoryPath, fileName);

// PDF Setup and Generation
QuestPDF.Settings.License = LicenseType.Community;
InvoiceDocument doc = new(invoice);
doc.GeneratePdf(fullPath);

// Open the generated file
Process.Start("explorer.exe", fullPath);