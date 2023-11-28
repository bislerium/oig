using oig.domain.source.faker.Entities;
using oig.pdf.Implementation;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Diagnostics;

QuestPDF.Settings.License = LicenseType.Community;

var invoice = InvoiceFaker.Generate();

var directoryPath = @"C:\Users\bisha\Desktop";
var fileName = @"invoice.pdf";
var fullPath = Path.Combine(directoryPath, fileName);

InvoiceDocument doc = new InvoiceDocument(invoice);

doc.GeneratePdf(fullPath);
Process.Start("explorer.exe", fullPath);